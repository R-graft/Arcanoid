using UnityEngine;

[CreateAssetMenu(fileName = "BlocksDataObject", menuName = "Data/newBlocksDataObject")]
public class BlocksData : ScriptableObject
{
    public Block[] blocksTypes;
}

