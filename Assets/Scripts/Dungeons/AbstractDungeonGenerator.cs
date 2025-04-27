using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class AbstractDungeonGenerator : MonoBehaviour
{
    [SerializeField]
    protected TilemapVisulizer tilemapVisulizer = null;
    [SerializeField]
    protected Vector2Int startPosition = Vector2Int.zero;

    public void GenerateDungeon() 
    {
        tilemapVisulizer.Clear();
        RunProceduralGeneration();
    }

    protected abstract void RunProceduralGeneration();
}
