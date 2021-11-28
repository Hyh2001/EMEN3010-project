using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float Speed;
    Vector2 worldPosLeftBottom;
    Vector2 worldPosTopRight;

    // Start is called before the first frame update
    void Start()
    {

    }
    //bullet scan
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Enemy")
        {
            SCORE.scoreValue += 10;
            //Get 10 point from destroy the small enemy or
            //destroy the bullet 
            Destroy(col.gameObject);


            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * 500 * Time.deltaTime, Space.World);
        worldPosLeftBottom = Camera.main.ViewportToWorldPoint(Vector2.zero);
        worldPosTopRight = Camera.main.ViewportToWorldPoint(Vector2.one);

        if (transform.position.y >= worldPosTopRight.y)
        {
            Destroy(gameObject);
            if (transform.position.magnitude > worldPosTopRight.y)
            {
                Destroy(this.gameObject);

            }

        }
    }
}
