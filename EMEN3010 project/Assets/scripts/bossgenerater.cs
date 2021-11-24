using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossgenerater : MonoBehaviour
{
    public GameObject BossEnemyPrefab;
    private int random;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BossSpawn", 1000f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void BossSpawn()
    {
        Instantiate(BossEnemyPrefab, transform.position, transform.rotation);
        CancelInvoke();
    }
}
