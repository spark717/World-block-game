using UnityEngine;
using System.Collections.Generic;

public class BlockGO : MonoBehaviour {

    private List<BlockGO> _sideBlocks = new List<BlockGO>();

    public void OnSideBlockDestroyed(BlockGO block)
    {
        _sideBlocks.Remove(block);
    }

    public void OnSideBlockCreated(BlockGO block)
    {
        _sideBlocks.Add(block);
    }
}
