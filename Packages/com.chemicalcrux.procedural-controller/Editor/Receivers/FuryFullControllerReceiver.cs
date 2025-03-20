using ChemicalCrux.ProceduralController.Editor.Interfaces;
using com.vrcfury.api;
using com.vrcfury.api.Components;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace ChemicalCrux.ProceduralController.Editor.Receivers
{
    public class FuryFullControllerReceiver : IReceiver
    {
        private readonly FuryFullController fc;
        
        public FuryFullControllerReceiver(GameObject target)
        {
            fc = FuryComponents.CreateFullController(target);
        }
        
        public void AddController(RuntimeAnimatorController controller, VRCAvatarDescriptor.AnimLayerType type = VRCAvatarDescriptor.AnimLayerType.FX)
        {
            fc.AddController(controller, type);
        }

        public void AddMenu(VRCExpressionsMenu menu, string path)
        {
            fc.AddMenu(menu, path);
        }

        public void AddParameters(VRCExpressionParameters parameters)
        {
            fc.AddParams(parameters);
        }

        public void AddGlobalParameter(string parameter)
        {
            fc.AddGlobalParam(parameter);
        }
    }
}