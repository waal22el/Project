using System;

 

using System.Collections;
 

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
 


 

public class CorridorFirstDungeonGenerator : DungeonGenerator
 

{
 

    [SerializeField]
 

    private int corridorLength = 14, corridorCount = 5;
 

    [SerializeField]
 

    [Range(0.1f,1)]
 

    private float roomPercent = 0.8f;
 
 


 

    protected override void RunProceduralGeneration()
 

    {
 

        CorridorFirstGeneration();
 

    }
 


 

    private void CorridorFirstGeneration()
 

    {
 

        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        HashSet<Vector2Int> potentialRoomPositions = new HashSet<Vector2Int>();

 


 

        CreateCorridors(floorPositions, potentialRoomPositions);

        HashSet<Vector2Int> roomPositions = CreateRooms(potentialRoomPositions);
 

        floorPositions.UnionWith(roomPositions);
 

        tilemapVisulizer.PaintFloorTiles(floorPositions);
 

        WallGenerator.CreateWalls(floorPositions, tilemapVisulizer);
 


 

    }

    private HashSet<Vector2Int> CreateRooms(HashSet<Vector2Int> potentialRoomPositions)
    {
        HashSet<Vector2Int> roomPositions = new HashSet<Vector2Int>();
        int roomCreateCount = Mathf.RoundToInt( potentialRoomPositions.Count * roomPercent);

        List<Vector2Int> roomsToCreate = potentialRoomPositions.OrderBy(x => Guid.NewGuid()).Take(roomCreateCount).ToList();

        foreach (var roomPosition in roomsToCreate)
        {
            var roomFloor = RunRandomWalk(randomWalkParameters, roomPosition); 
            roomPositions.UnionWith(roomFloor);
        }
        return roomPositions;
    }

    private void CreateCorridors(HashSet<Vector2Int> floorPositions,HashSet<Vector2Int> potentialRoomPositions )
 

    {
 

        var currentPosition = startPosition;
        potentialRoomPositions.Add(currentPosition);

        for (int i = 0; i < corridorCount; i++)
        {
 

            var corridor = ProceduralAlgorithms.RandomWalkCorridor(currentPosition, corridorLength);
 

            currentPosition = corridor[corridor.Count - 1];
            potentialRoomPositions.Add(currentPosition);
 

            floorPositions.UnionWith(corridor);
 

        }
 

    }
 

}