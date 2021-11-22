using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 650) == 1)
        {
            Vector3 pos = new Vector3(Random.Range(-2.8f, 2.8f), 5.5f, 0); 
            Instantiate(enemyPrefab, pos, Quaternion.identity);
        }

    }
}
