using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ball : MonoBehaviour
{
    public Animator animator;
    public GameManager manager;
    public Rigidbody rgb;
    public float jumpAmount = 6.0f;
    public GameObject finish;
    public GameObject paint;
    Vector3 paintVector;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "KirmiziKup")
        {
            animator.SetBool("Collider", true);
            Invoke("resetAnimation", 0.5f);
            rgb.velocity = Vector3.up * jumpAmount;
            paintVector = collision.contacts[0].point+ new Vector3(0,0.01f,0);
            GameObject newPaint = Instantiate(paint, paintVector, Quaternion.identity);
            newPaint.transform.parent = collision.gameObject.transform;
            Destroy(newPaint, 2.0f);
        }
        if (collision.gameObject.tag == "KirmiziKup")
        {
            manager.ReturnGame();
        }
        if (collision.gameObject.tag == "Plane") 
        {
            manager.NextLevel();
        }
        if (collision.gameObject.tag == "LastPlane")
        {
            finish.SetActive(true);
        }
    }
    void resetAnimation()
    {
        animator.SetBool("Collider", false);
    }
}
