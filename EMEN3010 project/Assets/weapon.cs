using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, Speed, 0) * Time.deltaTime;
        if (transform.position.y >= 5f)
        {
            Destroy(gameObject);
        }
    }
}
