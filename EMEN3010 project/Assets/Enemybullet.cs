using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -3f, 0) * Time.deltaTime;
        //destory ou of range
        if (transform.position.y < -3)
        {
            Destroy(gameObject);
        }
    }
}
