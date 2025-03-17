using System.Collections.Generic;
using ChemicalCrux.ProceduralController.Runtime.Models;
using UnityEngine;
using VRC.SDKBase;

namespace ChemicalCrux.ProceduralController.Runtime
{
    public class ProceduralControllerSetup : MonoBehaviour, IEditorOnly
    {
        public List<Model> models;
    }
}