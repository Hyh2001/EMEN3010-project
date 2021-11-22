using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    float Speed = 30.0f;
    public Rigidbody2D bullets;

    // Start is called before the first frame update
    void Start()
    {
        bullets.GetComponent<Rigidbody2D>();
        bullets.velocity = transform.up * Speed;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
