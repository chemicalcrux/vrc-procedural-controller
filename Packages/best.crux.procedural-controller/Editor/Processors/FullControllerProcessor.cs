using Crux.ProceduralController.Runtime.Models;
using JetBrains.Annotations;
using UnityEngine;

namespace Crux.ProceduralController.Editor.Processors
{
    [UsedImplicitly]
    public class FullControllerProcessor : Processor<FullControllerModel>
    {
        public override void Process(Context context)
        {
            if (!model.data.TryUpgradeTo(out FullControllerModelDataV1 data))
            {
                Debug.LogWarning("Failed to upgrade the full controller model's data.");
                return;
            }
            
            foreach (var controller in data.controllers)
                context.receiver.AddController(controller);

            foreach (var menuInfo in data.menus)
                context.receiver.AddMenu(menuInfo.menu, menuInfo.path);

            foreach (var parameterList in data.parameters)
                context.receiver.AddParameters(parameterList);

            foreach (var globalParam in data.globalParameters)
                context.receiver.AddGlobalParameter(globalParam);
        }
    }
}