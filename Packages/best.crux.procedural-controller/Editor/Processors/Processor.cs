using Crux.ProceduralController.Runtime.Interfaces;

namespace Crux.ProceduralController.Editor.Processors
{
    public abstract class Processor<ModelType> : ProcessorBase where ModelType : IModel
    {
        public ModelType model;
    }
}