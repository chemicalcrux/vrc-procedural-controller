using System;
using System.Collections.Generic;
using UnityEngine;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace Crux.ProceduralController.Runtime.Models
{
    [Serializable]
    public class MenuInfo
    {
        public VRCExpressionsMenu menu;
        public string path;
    }
    
    [CreateAssetMenu]
    public class FullControllerModel : AssetModel
    {
        public List<RuntimeAnimatorController> controllers;
        public List<MenuInfo> menus;
        public List<VRCExpressionParameters> parameters;
        public List<string> globalParameters;
    }
}