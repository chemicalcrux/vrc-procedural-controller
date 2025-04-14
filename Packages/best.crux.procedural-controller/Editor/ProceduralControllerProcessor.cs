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
            
            foreach (var setup in avatarGameObject.GetComponentsInChildren<ProceduralControllerSetup>())
            {
                Process(setup, avatarGameObject);
            }

            return true;
        }

        private static void Process(ProceduralControllerSetup setup, GameObject avatarRoot)
        {
            var context = new Context
            {
                avatarRoot = avatarRoot,
                targetObject = setup.gameObject,
                receiver = new FuryFullControllerReceiver(setup.gameObject)
            };

            if (!string.IsNullOrEmpty(setup.menuPrefix))
            {
                context.receiver = new MenuPrefixReceiver(context.receiver, setup.menuPrefix);
            }

            var models = Enumerable.Empty<IModel>()
                .Concat(setup.assetModels)
                .Concat(setup.componentModels);
            
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