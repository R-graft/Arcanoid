
public class FactoryBlock<T> : AbstractFactory<T> where T : Block
{
    private T _creatingObject;

    private BlocksSystem _blocksController;
    public FactoryBlock(T currentBlockType, BlocksSystem controller)
    {
        _creatingObject = currentBlockType;

        _blocksController = controller;
    }

    public override T CreateObject()
    {
        var creatingBlock = Instantiate(_creatingObject, _blocksController.transform);

        creatingBlock._blocksSystem = _blocksController;

        return creatingBlock;
    }
}
    
