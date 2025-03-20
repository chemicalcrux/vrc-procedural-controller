using ChemicalCrux.ProceduralController.Runtime.Interfaces;

namespace ChemicalCrux.ProceduralController.Editor.Processors
{
    public abstract class Processor<ModelType> : ProcessorBase where ModelType : IModel
    {
        public ModelType model;
    }
}