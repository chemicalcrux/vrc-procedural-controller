using System;
using Crux.Core.Runtime;
using Crux.Core.Runtime.Upgrades;
using UnityEngine;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace Crux.ProceduralController.Runtime.Models
{
    [CreateAssetMenu(menuName = Consts.AssetRootPath + "Full Controller Model")]
    public class FullControllerModel : AssetModel
    {
        [SerializeField, SerializeReference]
        public FullControllerModelData data = new FullControllerModelDataV1();
    }

    [Serializable]
    [UpgradableLatestVersion(1)]
    public abstract class FullControllerModelData : Upgradable<FullControllerModelData>
    {
        
    }

    [Serializable]
    [UpgradableVersion(1)]
    public class FullControllerModelDataV1 : FullControllerModelData
    {
        [Serializable]
        public class MenuInfo
        {
            public VRCExpressionsMenu menu;
            public string path;
        }
        
        [SerializeField] public DecoratedList<RuntimeAnimatorController> controllers;
        [SerializeField] public DecoratedList<MenuInfo> menus;
        [SerializeField] public DecoratedList<VRCExpressionParameters> parameters;
        [SerializeField] public DecoratedList<string> globalParameters;
        
        public override FullControllerModelData Upgrade()
        {
            return this;
        }
    }
}