using System.Linq;
using Crux.ProceduralController.Editor.Receivers;
using Crux.ProceduralController.Runtime;
using Crux.ProceduralController.Runtime.Interfaces;
using UnityEngine;
using VRC.SDKBase.Editor.BuildPipeline;

namespace Crux.ProceduralController.Editor
{
    public class ProceduralControllerProcessor : IVRCSDKPreprocessAvatarCallback
    {
        public int callbackOrder => -11000;
        
        public bool OnPreprocessAvatar(GameObject avatarGameObject)
        {
            ProcessorLocator.Refresh();
            
            foreach (var setup in avatarGameObject.GetComponentsInChildren<ProceduralControllerBuilder>())
            {
                Process(setup, avatarGameObject);
            }

            return true;
        }

        private static void Process(ProceduralControllerBuilder builder, GameObject avatarRoot)
        {
            if (!builder.data.TryUpgradeTo(out ProceduralControllerDataV1 data))
            {
                Debug.LogWarning("Failed to upgrade the procedural controller's data.");
                return;
            }
            
            var context = new Context
            {
                avatarRoot = avatarRoot,
                targetObject = builder.gameObject,
                receiver = new FuryFullControllerReceiver(builder.gameObject)
            };

            if (!string.IsNullOrEmpty(data.menuPrefix))
            {
                context.receiver = new MenuPrefixReceiver(context.receiver, data.menuPrefix);
            }

            var models = Enumerable.Empty<IModel>()
                .Concat(data.assetModels)
                .Concat(data.componentModels);
            
            foreach (var model in models)
            {
                foreach (var processor in ProcessorLocator.GetProcessors(model))
                {
                    Debug.Log("Running " + processor + " on " + model);
                    processor.Process(context);
                }

                context.NewScope();
            }
        }
    }
}