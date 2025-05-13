using System;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    [SerializeField] private GameObject horizontalWall;
    [SerializeField] private GameObject verticalWall;
    [SerializeField] private int roomSize = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        horizontalWall = GetComponent<GameObject>();
        verticalWall = GetComponent<GameObject>();
        createRoom(roomSize, horizontalWall, verticalWall);
    }

    private void createRoom(int roomSize, GameObject horizontalWall, GameObject verticalWall)
    {
        GameObject hWall = horizontalWall;
        GameObject vWall = verticalWall;

        Vector3 originalHScale = horizontalWall.transform.localScale;
        Vector3 originalVScale = verticalWall.transform.localScale;

        hWall.transform.localScale = new Vector3 (originalHScale.x * roomSize, originalHScale.y * roomSize, originalHScale.z);
        vWall.transform.localScale = new Vector3 (originalVScale.x * roomSize, originalVScale.y * roomSize, originalVScale.z);

        Vector3 verticalRightPosition = new Vector3(roomSize / 2, 0, verticalWall.transform.position.z);
        Vector3 verticalLeftPosition = new Vector3(-(roomSize / 2), 0, verticalWall.transform.position.z);

        Vector3 horizontalTopPosition = new Vector3(0, roomSize / 2, verticalWall.transform.position.z);
        Vector3 horizontalBottomPosition = new Vector3(0, -roomSize / 2, verticalWall.transform.position.z);

        Instantiate(vWall, verticalLeftPosition, Quaternion.identity);
        Instantiate(vWall, verticalRightPosition, Quaternion.identity);

        Instantiate(hWall, horizontalTopPosition, Quaternion.identity);
        Instantiate(hWall, horizontalBottomPosition, Quaternion.identity);


    }
}
