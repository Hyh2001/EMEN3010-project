using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    //bullet scan
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Enemy")
        {
           
            Destroy(col.gameObject);

            
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * 2 * Time.deltaTime, Space.World);


        if (transform.position.y >= 5f)
        {
            Destroy(gameObject);
        }

    }
}
