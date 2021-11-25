
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybullet : MonoBehaviour
{
   
    

    
    void Update()
    {
        transform.position += new Vector3(0, -300f, 0) * Time.deltaTime;
        //destory out of range
        if (transform.position.y < -520)
        {
            Destroy(gameObject);
        }
    }
}
