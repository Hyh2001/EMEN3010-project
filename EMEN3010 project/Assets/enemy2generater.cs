using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2generater : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 1500) == 1)
        {
            Vector3 pos = new Vector3(Random.Range(-500f, 500f), 550f, 0);
            Instantiate(enemyPrefab, pos, Quaternion.identity);
        }
    }
   
    
}
