using Crux.ProceduralController.Editor.Interfaces;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace Crux.ProceduralController.Editor.Receivers
{
    public class MenuPrefixReceiver : IReceiver
    {
        private readonly IReceiver nested;
        private readonly string prefix;

        public MenuPrefixReceiver(IReceiver nested, string prefix)
        {
            this.nested = nested;
            this.prefix = prefix;
        }
        
        public void AddController(RuntimeAnimatorController controller, VRCAvatarDescriptor.AnimLayerType type = VRCAvatarDescriptor.AnimLayerType.FX)
        {
            nested.AddController(controller);
        }

        public void AddMenu(VRCExpressionsMenu menu, string path)
        {
            nested.AddMenu(menu, prefix + path);
        }

        public void AddParameters(VRCExpressionParameters parameters)
        {
            nested.AddParameters(parameters);
        }

        public void AddGlobalParameter(string parameter)
        {
            nested.AddGlobalParameter(parameter);
        }
    }
}