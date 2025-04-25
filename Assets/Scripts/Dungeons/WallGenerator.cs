using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static ProceduralAlgorithms;

public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TilemapVisulizer tilemapVisulizer)
    {
        var basicWallPositions = FindWallsInDirections(floorPositions, Direction2D.cardinalDirectionsList);
        foreach(var position in basicWallPositions)
        {
            tilemapVisulizer.PaintSingeBasicWall(position);
        }
    }

    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach(var position in floorPositions)
        {
            foreach(var direcion in directionList)
            {
                var neighbourPosition = position + direcion;
                if(floorPositions.Contains(neighbourPosition) == false)
                {
                    wallPositions.Add(neighbourPosition);
                }
            }
        }
        return wallPositions;
    }
}
