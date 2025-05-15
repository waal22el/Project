using System.Collections.Generic;
using UnityEngine;

public static class Directions
{
    public static List<Vector3> cardinalDirectionsList = new List<Vector3>
        {
            new Vector3(0,1,0), //Up
            new Vector3(0,-1,0), //Down
            new Vector3(1,0,0), //Right
            new Vector3(-1,0,0)//Left
        };

    
}