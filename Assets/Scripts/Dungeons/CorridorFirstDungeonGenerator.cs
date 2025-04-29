using System;

 

using System.Collections;
 

using System.Collections.Generic;
 

using UnityEngine;
 


 

public class CorridorFirstDungeonGenerator : DungeonGenerator
 

{
 

    [SerializeField]
 

    private int corridorLength = 14, corridorCount = 5;
 

    [SerializeField]
 

    [Range(0.1f,1)]
 

    private float roomPercent = 0.8f;
 

    [SerializeField]
 

    public SimpleRandomData roomGenerationParameters;
 


 

    protected override void RunProceduralGeneration()
 

    {
 

        CorridorFirstGeneration();
 

    }
 


 

    private void CorridorFirstGeneration()
 

    {
 

        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
 


 

        CreateCorridors(floorPositions);
 


 

        tilemapVisulizer.PaintFloorTiles(floorPositions);
 

        WallGenerator.CreateWalls(floorPositions, tilemapVisulizer);
 


 

    }
 


 

    private void CreateCorridors(HashSet<Vector2Int> floorPositions)
 

    {
 

        var currentPosition = startPosition;
 


 

        for (int i = 0; i < corridorCount; i++)
 

        {
 

            var corridor = ProceduralAlgorithms.RandomWalkCorridor(currentPosition, corridorLength);
 

            currentPosition = corridor[corridor.Count - 1];
 

            floorPositions.UnionWith(corridor);
 

        }
 

    }
 

}