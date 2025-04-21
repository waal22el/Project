using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisulizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap, wallTilemap;
    [SerializeField]
    private TileBase floorTile, wallTop; 

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintFloorTiles(floorPositions, floorTilemap, floorTile);
    }

    private void PaintFloorTiles(IEnumerable<Vector2Int> positions, Tilemap Tilemap, TileBase Tile)
    {
        foreach(var position in positions)
        {
            PaintSingleTile(Tilemap, Tile, position);
        }
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    public void Clear()
    {
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
    }

    internal void PaintSingeBasicWall(Vector2Int position)
    {
        PaintSingleTile(wallTilemap, wallTop, position);
    }
}
