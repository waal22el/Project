using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class DungeonGenerator : AbstractDungeonGenerator
{

    [SerializeField]
    private SimpleRandomData randomWalkParameters;

    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk(randomWalkParameters);
        tilemapVisulizer.Clear();
        tilemapVisulizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tilemapVisulizer);
    }

  

    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomData parameters)
    {
        var currentPosition = startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();

        for (int i = 0; i < parameters.iterations; i++)
        {
            var path = ProceduralAlgorithms.SimpleRandomWalk(currentPosition, parameters.walkLength);            floorPositions.UnionWith(path);

            if (parameters.startRandomlyEachIteration)
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
        }
        return floorPositions;
    }
}
