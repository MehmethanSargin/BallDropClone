using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    float horizontal;
    float speed = 200.0f;
    Touch touch;
    void Update()
    {
        
        horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);
    }
}
