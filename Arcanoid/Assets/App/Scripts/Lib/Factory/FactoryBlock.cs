
public class FactoryBlock<T> : AbstractFactory<T> where T : Block
{
    private T _creatingObject;

    private GridSystem _grid;
    public FactoryBlock(T currentObject, GridSystem grid)
    {
        _creatingObject = currentObject;

        _grid = grid;
    }

    public override T CreateObject()
    {
        var creatingObject = Instantiate(_creatingObject, _grid.transform);

        return creatingObject;
    }
}
    
