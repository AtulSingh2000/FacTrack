using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    private Rigidbody rb;
    public float scrollSpeed = -1.5f;


    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb = GetComponent<Rigidbody>();

        //Start the object moving.
        rb.velocity = new Vector2(0, scrollSpeed);
    }

    void Update()
    {
       
    }
}
