using Crux.ProceduralController.Editor.Interfaces;
using JetBrains.Annotations;
using UnityEngine;

namespace Crux.ProceduralController.Editor
{
    [PublicAPI]
    public class Context
    {
        public GameObject avatarRoot;
        public GameObject targetObject;
        
        public IReceiver receiver;

        private int scopeCounter;
        
        /// <summary>
        /// Gives a unique prefix to the parameter. This should be used for any parameter
        /// that should be isolated from other models in the same Procedural Controller.
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public string MakeParam(string paramName) => $"PC_{scopeCounter:D3}_" + paramName;
        
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