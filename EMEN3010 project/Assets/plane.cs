using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane : MonoBehaviour
{
    Rigidbody2D plane;
    float force = 200.0f;

    // Start is called before the first frame update
    void Start()
    {
        plane = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            plane.AddForce
        }
    }
}
