using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Search;
using UnityEngine;

public static class ProceduralAlgorithms 
{
    public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();
        path.Add(startPosition);
        var previousPosition = startPosition;

        for (int i = 0; i < walkLength; i++)
        {
            var newPosition = previousPosition + Direction2D.GetRandomCardinalDirection();
            path.Add(newPosition);
            previousPosition = newPosition;
        }
        return path;
    }

     

    
 

    public static List<Vector2Int> RandomWalkCorridor(Vector2Int startPosition, int corridorLength)
 

    {
 

        List<Vector2Int> corridor = new List<Vector2Int>();
 

        var direction = Direction2D.GetRandomCardinalDirection();
 

        var currentPosition = startPosition;
 

        corridor.Add(currentPosition);
 


 

        for (int i = 0; i < corridorLength; i++)
 

        {
 

            currentPosition += direction;
 

            corridor.Add(currentPosition);
 

        }
 

        return corridor;
 

    }

    public static class Direction2D
    {
        public static List<Vector2Int> cardinalDirectionsList = new List<Vector2Int>
        {
            new Vector2Int(0,1), //Up
            new Vector2Int(0,-1), //Down
            new Vector2Int(1,0), //Right
            new Vector2Int(-1,0)//Left
        };

        public static Vector2Int GetRandomCardinalDirection()
        {
            return cardinalDirectionsList[Random.Range(0, cardinalDirectionsList.Count)];
        }
    }
}
