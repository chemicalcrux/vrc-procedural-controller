using System;
using Crux.Core.Runtime;
using Crux.Core.Runtime.Attributes;
using Crux.Core.Runtime.Upgrades;
using Crux.ProceduralController.Runtime.Models;
using UnityEngine;

namespace Crux.ProceduralController.Runtime
{
    [Serializable]
    [UpgradableLatestVersion(version: 1)]
    public abstract class ProceduralControllerData : Upgradable<ProceduralControllerData>
    {
        
    }

    [Serializable]
    [UpgradableVersion(version: 1)]
    public class ProceduralControllerDataV1 : ProceduralControllerData
    {
        [TooltipRefInert("f257634aabcbb4477bd8fbc255ce64b3,9197481963319205126")]
        [SerializeField] internal DecoratedList<AssetModel> assetModels;
        [TooltipRefInert("62be95ed7dd0a4c65bcbb3afd79ab524,9197481963319205126")]
        [SerializeField] internal DecoratedList<ComponentModel> componentModels;

        [TooltipRef("d79fedb36e6c5494b888c685b11c0de0,9197481963319205126")]
        [SerializeField] internal string menuPrefix;
        [TooltipRef("49cbbbb2739404b16b87236f02f5bbf7,9197481963319205126")]
        [SerializeField] internal Texture2D menuIcon;
        
        public override ProceduralControllerData Upgrade()
        {
            return this;
        }
    }
}