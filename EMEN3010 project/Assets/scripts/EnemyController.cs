using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Speed;     
    private float pointY;   
    private float vx;          
    private GameObject player;
    Vector2 worldPosLeftBottom;
    // Start is called before the first frame update
    void Start()
    {
        pointY = Random.Range(2.0f, 3.0f);
        
        vx = 1.0f;
        player = GameObject.Find("plane-removebg-preview");
        if (player.transform.position.x < transform.position.x)
        {
            vx = -vx;
        }

    }

    // Update is called once per frame
    void Update()
    {
        

        if (transform.position.y < -420f)
        {
            Destroy(gameObject);
        }


        if (transform.position.y < pointY)
        {
            transform.position += new Vector3(vx, 0, 0) * Time.deltaTime;
        }

        transform.position += new Vector3(0, -Speed, 0) * Time.deltaTime;




    }
}