using System.Collections.Generic;
using Crux.ProceduralController.Runtime.Models;
using UnityEngine;
using VRC.SDKBase;

namespace Crux.ProceduralController.Runtime
{
    public class ProceduralControllerSetup : MonoBehaviour, IEditorOnly
    {
        public List<AssetModel> assetModels;
        public List<ComponentModel> componentModels;

        public string menuPrefix;
    }
}