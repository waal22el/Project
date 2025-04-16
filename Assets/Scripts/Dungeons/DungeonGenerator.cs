using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class DungeonGenerator : MonoBehaviour
{
    [SerializeField]
    protected Vector2Int startingPosition;

    [SerializeField]
    private int iterations = 10;
    [SerializeField]
    private int walkLength = 10;
    [SerializeField]
    private bool startFromRandomPositionEachIteration = true;

    public void runProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = runRandomWalk();
        foreach (var floor in floorPositions)
        {
            Debug.Log(floor);
        }
    }

    private HashSet<Vector2Int> runRandomWalk()
    {
        var currentPosition = startingPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();

        for (int i = 0; i < iterations; i++)
        {
            var path = ProceduralAlgorithms.SimpleRandomWalk(currentPosition, walkLength);
            floorPositions.UnionWith(path);

            if (startFromRandomPositionEachIteration)
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
        }
        return floorPositions;
    }
}
