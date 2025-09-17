using System.Linq;
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
        private readonly Texture2D menuIcon;

        private bool menuAdded = false;

        public MenuPrefixReceiver(IReceiver nested, string prefix, Texture2D menuIcon)
        {
            this.nested = nested;
            this.prefix = prefix;
            this.menuIcon = menuIcon;
        }

        public void AddController(RuntimeAnimatorController controller,
            VRCAvatarDescriptor.AnimLayerType type = VRCAvatarDescriptor.AnimLayerType.FX)
        {
            nested.AddController(controller);
        }

        public void AddMenu(VRCExpressionsMenu menu, string path)
        {
            if (!menuAdded)
            {
                var prefixParts = prefix.Trim('/').Split("/");

                if (prefixParts.Length > 0)
                {
                    var suffix = prefixParts[^1];
                    var holderPath = prefixParts.SkipLast(1).Aggregate("", (cur, next) => cur + "/" + next);

                    var rootMenu = ScriptableObject.CreateInstance<VRCExpressionsMenu>();
                    var suffixMenu = ScriptableObject.CreateInstance<VRCExpressionsMenu>();

                    rootMenu.controls.Add(new VRCExpressionsMenu.Control
                    {
                        icon = menuIcon,
                        name = suffix,
                        subMenu = suffixMenu,
                        type = VRCExpressionsMenu.Control.ControlType.SubMenu,
                    });

                    nested.AddMenu(rootMenu, holderPath);
                }
                
                menuAdded = true;
            }

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