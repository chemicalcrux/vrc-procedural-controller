using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ChemicalCrux.ProceduralController.Editor.Processors;
using ChemicalCrux.ProceduralController.Runtime.Models;
using UnityEngine;

namespace ChemicalCrux.ProceduralController.Editor
{
    // I don't know if this is what "service locator" means, but whatever
    public static class ServiceLocator
    {
        private static List<Type> _processorTypes;
        private static Dictionary<Type, List<Type>> _processorMap;

        public static void Refresh()
        {
            _processorTypes = new();
            _processorMap = new();

            Type baseProcessorType = typeof(Processor<>);
            Type baseModelType = typeof(Model);
            
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies().Where(asm => !asm.IsDynamic))
            {
                foreach (var type in assembly.ExportedTypes)
                {
                    if (baseModelType.IsAssignableFrom(type) && !type.IsAbstract)
                    {
                        Debug.Log("Model: " + type);
                        _processorMap[type] = new();
                    }
                }
            }

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies().Where(asm => !asm.IsDynamic))
            {
                foreach (var type in assembly.ExportedTypes)
                {
                    Type current = type;
                    
                    while (current != null && (!current.IsGenericType || current.GetGenericTypeDefinition() != baseProcessorType))
                    {
                        current = current.BaseType;
                    }

                    if (current == null)
                    {
                        continue;
                    }

                    Debug.Log("Considering: " + type);
                    
                    foreach (var modelType in _processorMap.Keys)
                    {
                        var candidateType = baseProcessorType.MakeGenericType(modelType);

                        Debug.Log("Trying: " + candidateType);
                        if (candidateType.IsAssignableFrom(current))
                        {
                            Debug.Log("Hit!");
                            _processorMap[modelType].Add(type);
                        }
                    }
                }
            }
        }

        public static IEnumerable<ProcessorBase> GetProcessors(Model model)
        {
            foreach (var processorType in _processorMap[model.GetType()])
            {
                Debug.Log("Activating: " + processorType);
                
                var processor = (ProcessorBase) Activator.CreateInstance(processorType);
                var field = processorType.GetField("model", BindingFlags.Public | BindingFlags.Instance);
                field.SetValue(processor, model);
                
                yield return processor;
            }
        }
    }
}