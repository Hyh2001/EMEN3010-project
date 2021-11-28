using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossbullet : MonoBehaviour
{
    float dx;
    float dy;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Setting(float angle, float speed)
    {

        dx = Mathf.Cos(angle) * speed;
        dy = Mathf.Sin(angle) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(dx, dy, 0) * Time.deltaTime;

        if (transform.position.x < -890 || transform.position.x > 890 ||
            transform.position.y < -500 || transform.position.y > 500)
        {
            Destroy(gameObject);
        }
    }
}
