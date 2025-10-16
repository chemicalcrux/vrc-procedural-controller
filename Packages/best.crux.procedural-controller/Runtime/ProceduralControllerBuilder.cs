using Crux.Core.Runtime.Attributes;
using UnityEngine;
using VRC.SDKBase;

namespace Crux.ProceduralController.Runtime
{
    [AddComponentMenu(menuName: Consts.ComponentRootPath + "Procedural Controller")]
    [HideIcon]
    public class ProceduralControllerBuilder : MonoBehaviour, IEditorOnly
    {
        [SerializeField, SerializeReference] internal ProceduralControllerData data = new ProceduralControllerDataV1();
    }
}