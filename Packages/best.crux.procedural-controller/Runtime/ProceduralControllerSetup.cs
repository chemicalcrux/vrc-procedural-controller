using UnityEngine;
using VRC.SDKBase;

namespace Crux.ProceduralController.Runtime
{
    public class ProceduralControllerSetup : MonoBehaviour, IEditorOnly
    {
        [SerializeField, SerializeReference] internal ProceduralControllerData data = new ProceduralControllerDataV1();
    }
}