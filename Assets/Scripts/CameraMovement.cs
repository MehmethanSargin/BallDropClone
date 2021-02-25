using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public GameManager manager;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;
    List<GameObject> obstacles;
    private void Awake()
    {
        obstacles = new List<GameObject>();
        GameObject[] floors = GameObject.FindGameObjectsWithTag("KirmiziKup");
        foreach (GameObject floor in floors)
        {
            obstacles.Add(floor);
        }
        manager.allObstacle = (float)obstacles.Count;
    }
 private void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
        foreach (GameObject coordinate in obstacles)
            if (target.position.y <= coordinate.transform.position.y)
            {
                manager.passObstacle();
                obstacles.Remove(coordinate);
            }
    }
}



   


