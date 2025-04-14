using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Crux.ProceduralController.Editor.Processors;
using Crux.ProceduralController.Runtime.Interfaces;

namespace Crux.ProceduralController.Editor
{
    /// <summary>
    /// This is pretty basic -- for a given type T, it'll find every class that is assignable
    /// to Processor&lt;T&gt;
    ///
    /// This is necessary because the models are separated from the actual processing logic.
    /// The models don't say "I'm Foo, and I need to be processed by Bar" -- instead, Bar says "I want to
    /// operate on every instance of Foo"
    /// </summary>
    public static class ProcessorLocator
    {
        private static List<Type> _processorTypes;
        private static Dictionary<Type, List<Type>> _processorMap;

        public static void Refresh()
        {
            _processorTypes = new();
            _processorMap = new();

            Type baseProcessorType = typeof(Processor<>);
            Type baseModelType = typeof(IModel);
            
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies().Where(asm => !asm.IsDynamic))
            {
                foreach (var type in assembly.ExportedTypes)
                {
                    if (baseModelType.IsAssignableFrom(type) && !type.IsAbstract)
                    {
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

                    foreach (var modelType in _processorMap.Keys)
                    {
                        var candidateType = baseProcessorType.MakeGenericType(modelType);

                        if (candidateType.IsAssignableFrom(current))
                        {
                            _processorMap[modelType].Add(type);
                        }
                    }
                }
            }
        }

        public static IEnumerable<ProcessorBase> GetProcessors(IModel model)
        {
            foreach (var processorType in _processorMap[model.GetType()])
            {
                var processor = (ProcessorBase) Activator.CreateInstance(processorType);
                
                var field = processorType.GetField("model", BindingFlags.Public | BindingFlags.Instance);
                field.SetValue(processor, model);
                
                yield return processor;
            }
        }
    }
}