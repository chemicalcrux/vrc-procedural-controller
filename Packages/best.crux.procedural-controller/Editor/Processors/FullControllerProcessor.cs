using Crux.ProceduralController.Runtime.Models;

namespace Crux.ProceduralController.Editor.Processors
{
    public class FullControllerProcessor : Processor<FullControllerModel>
    {
        public override void Process(Context context)
        {
            foreach (var controller in model.controllers)
                context.receiver.AddController(controller);

            foreach (var menuInfo in model.menus)
                context.receiver.AddMenu(menuInfo.menu, menuInfo.path);

            foreach (var parameterList in model.parameters)
                context.receiver.AddParameters(parameterList);

            foreach (var globalParam in model.globalParameters)
                context.receiver.AddGlobalParameter(globalParam);
        }
    }
}