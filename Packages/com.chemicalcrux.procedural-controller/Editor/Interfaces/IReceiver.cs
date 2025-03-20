using UnityEngine;
using VRC.SDK3.Avatars.Components;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace ChemicalCrux.ProceduralController.Editor.Interfaces
{
    public interface IReceiver
    {
        public void AddController(RuntimeAnimatorController controller, VRCAvatarDescriptor.AnimLayerType type = VRCAvatarDescriptor.AnimLayerType.FX);
        public void AddMenu(VRCExpressionsMenu menu, string path);
        public void AddParameters(VRCExpressionParameters parameters);
        public void AddGlobalParameter(string parameter);
    }
}