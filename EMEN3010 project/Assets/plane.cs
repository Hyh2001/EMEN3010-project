using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane : MonoBehaviour
{
    Rigidbody2D plane1;
    float force = 50.0f;
    float speed = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        plane1 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        int direction = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1;
            plane1.AddForce(transform.right * direction * speed);
            //      plane1.velocity.x = direction * speed;

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1;
            plane1.AddForce(transform.right * direction * speed);
            //          plane1.velocity.x = direction * speed;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = 1;
            plane1.AddForce(transform.up * direction * speed);
            //      plane1.velocity.x = direction * speed;

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = -1;
            plane1.AddForce(transform.up * direction * speed);
            //      plane1.velocity.x = direction * speed;

        }
        plane1.velocity = Vector2.zero;
        /*        if (Input.GetKeyUp(KeyCode.RightArrow || KeyCode.LeftArrow || KeyCode.UpArrow ||  KeyCode.DownArrow))
                {

                    plane1.velocity = Vector2.zero;
                }*/
    }
}
