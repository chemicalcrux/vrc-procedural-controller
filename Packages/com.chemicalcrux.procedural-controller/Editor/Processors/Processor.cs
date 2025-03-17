namespace ChemicalCrux.ProceduralController.Editor.Processors
{
    public abstract class Processor<ModelType> : ProcessorBase
    {
        public ModelType model;
    }
}