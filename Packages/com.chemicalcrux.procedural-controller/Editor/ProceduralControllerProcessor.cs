using ChemicalCrux.ProceduralController.Runtime;
using com.vrcfury.api;
using UnityEngine;
using VRC.SDKBase.Editor.BuildPipeline;

namespace ChemicalCrux.ProceduralController.Editor
{
    public class ProceduralControllerProcessor : IVRCSDKPreprocessAvatarCallback
    {
        public int callbackOrder => -11000;
        
        public bool OnPreprocessAvatar(GameObject avatarGameObject)
        {
            ServiceLocator.Refresh();
            
            foreach (var setup in avatarGameObject.GetComponentsInChildren<ProceduralControllerSetup>())
            {
                Process(setup, avatarGameObject);
            }

            return true;
        }

        private static void Process(ProceduralControllerSetup setup, GameObject avatarRoot)
        {
            var context = new Context()
            {
                avatarRoot = avatarRoot,
                furyFullController = FuryComponents.CreateFullController(setup.gameObject)
            };

            foreach (var model in setup.models)
            {
                foreach (var processor in ServiceLocator.GetProcessors(model))
                {
                    Debug.Log("Running " + processor + " on " + model);
                    processor.Process(context);
                }
            }
        }
    }
}