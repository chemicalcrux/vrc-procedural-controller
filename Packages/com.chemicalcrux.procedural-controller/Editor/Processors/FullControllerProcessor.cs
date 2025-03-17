using ChemicalCrux.ProceduralController.Runtime;
using ChemicalCrux.ProceduralController.Runtime.Models;

namespace ChemicalCrux.ProceduralController.Editor.Processors
{
    public class FullControllerProcessor : Processor<FullControllerModel>
    {
        public override void Process(Context context)
        {
            foreach (var controller in model.controllers)
                context.furyFullController.AddController(controller);

            foreach (var menuInfo in model.menus)
                context.furyFullController.AddMenu(menuInfo.menu, menuInfo.path);

            foreach (var parameterList in model.parameters)
                context.furyFullController.AddParams(parameterList);

            foreach (var globalParam in model.globalParameters)
                context.furyFullController.AddGlobalParam(globalParam);
        }
    }
}