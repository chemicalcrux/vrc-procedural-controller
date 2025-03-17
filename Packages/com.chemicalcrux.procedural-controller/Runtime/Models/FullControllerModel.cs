using System;
using System.Collections.Generic;
using UnityEngine;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace ChemicalCrux.ProceduralController.Runtime.Models
{
    [Serializable]
    public class MenuInfo
    {
        public VRCExpressionsMenu menu;
        public string path;
    }
    
    public class FullControllerModel : Model
    {
        public List<RuntimeAnimatorController> controllers;
        public List<MenuInfo> menus;
        public List<VRCExpressionParameters> parameters;
        public List<string> globalParameters;
    }
}