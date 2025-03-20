using ChemicalCrux.ProceduralController.Editor.Interfaces;
using JetBrains.Annotations;
using UnityEngine;

namespace ChemicalCrux.ProceduralController.Editor
{
    [PublicAPI]
    public class Context
    {
        public GameObject avatarRoot;
        public GameObject targetObject;
        
        public IReceiver receiver;

        private int scopeCounter;
        
        /// <summary>
        /// Gives a unique prefix to the parameter.
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public string MakeParam(string paramName) => $"PC_{scopeCounter:N3}_" + paramName;
        
        /// <summary>
        /// Creates a new parameter scope. Parameters produced by MakeParam will not overlap with
        /// parameters produced by MakeParam in an older scope.
        /// </summary>
        public void NewScope()
        {
            ++scopeCounter;
        }
    }
}