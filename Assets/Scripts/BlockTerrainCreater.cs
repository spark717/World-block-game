using UnityEngine;

public class BlockTerrainCreater : MonoBehaviour {

    public ObjectMediator OM;
    public int _Length;
    public int _Widht;
    public float _Distance;

    private GameObject _blockPrefab;

    void Awake()
    {
        SetLinkedObjects();
        CreateTerrainWithBlocks();
    }


    private void SetLinkedObjects()
    {
        _blockPrefab = OM.BlockPrefab;
    }


    private void CreateTerrainWithBlocks()
    {
        var goFactory1 = new InstantiateGameObjectsM2
        {
            Prefab = _blockPrefab,
            BasicName = "block1",
            Widht = _Widht,
            Length = _Length,
            Distance = _Distance          
        };
        goFactory1.Create();

        var goFactory2 = new InstantiateGameObjectsM2
        {
            Prefab = _blockPrefab,
            BasicName = "block2",
            Widht = _Widht,
            Length = _Length,
            Distance = _Distance,
            StartPosition = new Vector3(0,1,0)
        };
        goFactory2.Create();
    }
}