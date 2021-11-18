using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane : MonoBehaviour
{
    Rigidbody2D plane1;
    float force = 50.0f;
    float speed = 50.0f;
    Vector2 worldPosLeftBottom;
    Vector2 worldPosTopRight;
    // Start is called before the first frame update
    void Start()
    {
        plane1 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // the first part is the control of motion:
        // using arrows to control
        // the range of moving is confined to the maincamera
        // and there is a delfection to make sure that the whole plane is inside the screen


        worldPosLeftBottom = Camera.main.ViewportToWorldPoint(Vector2.zero);
        worldPosTopRight = Camera.main.ViewportToWorldPoint(Vector2.one);
        int direction = 0;
        float deflect = 0.6f;
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
        plane1.position = new Vector2(Mathf.Clamp(plane1.position.x, worldPosLeftBottom.x + deflect, worldPosTopRight.x - deflect), Mathf.Clamp(plane1.position.y, worldPosLeftBottom.y + deflect, worldPosTopRight.y - deflect));
        /*        if (Input.GetKeyUp(KeyCode.RightArrow || KeyCode.LeftArrow || KeyCode.UpArrow ||  KeyCode.DownArrow))
                {

                    plane1.velocity = Vector2.zero;
                }*/


        // the second part will be shoot bullets out




    }
}
