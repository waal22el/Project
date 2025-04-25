using UnityEngine;

public class Dungeon4doorRoom : MonoBehaviour
{
    public GameObject room;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 spawnposition = transform.position + transform.forward * 7;
        GameObject roomObj = Instantiate(room, spawnposition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
