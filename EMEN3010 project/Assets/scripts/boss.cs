using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    GameObject player;
    public bossbullet bulletPrefab;
    int Hp = 7;
    AudioSource audioSource;
    public AudioClip shotSE;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("plane-removebg-preview");
        StartCoroutine(CPU());
        audioSource = GetComponent<AudioSource>();
    }
    void Shot(float angle, float speed)
    {
        bossbullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.Setting(angle, speed); // Mathf.PI/4fは45°
        audioSource.PlayOneShot(shotSE);
    }
    IEnumerator CPU()
    {
        // 位置
        while (transform.position.y > 100f)
        {
            transform.position -= new Vector3(0, 100, 0) * Time.deltaTime;
            yield return null; //(0.02秒)
        }
        while (true)
        {
            yield return WaveNShotM(4, 8);
            yield return new WaitForSeconds(2f);
            yield return WaveNShotMCurve(4, 16);
            yield return new WaitForSeconds(2f);
            yield return WaveNPlayerAimShot(4, 6);
            yield return new WaitForSeconds(2f);
        }
    }
    IEnumerator WaveNShotM(int n, int m)
    {
        // 4 times 8 directions
        for (int w = 0; w < n; w++)
        {
            yield return new WaitForSeconds(0.3f);
            ShotN(m, 200);
        }
    }
    IEnumerator WaveNShotMCurve(int n, int m)
    {
        // 4 times 8 directions
        for (int w = 0; w < n; w++)
        {
            yield return new WaitForSeconds(0.3f);
            yield return ShotNCurve(m, 200);
        }
    }

    void ShotN(int count, float speed)
    {
        int bulletCount = count;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount); // 2PI：360
            Shot(angle, speed);
        }
    }
    IEnumerator WaveNPlayerAimShot(int n, int m)
    {
        // shoot 4 times in 8 directions
        for (int w = 0; w < n; w++)
        {
            yield return new WaitForSeconds(1f);
            PlayerAimShot(m, 300);
        }
    }
    IEnumerator ShotNCurve(int count, float speed)
    {
        int bulletCount = count;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount); // 2PI：360
            Shot(angle - Mathf.PI / 2f, speed);
            Shot(-angle - Mathf.PI / 2f, speed);
            yield return new WaitForSeconds(0.1f);
        }
    }
    void PlayerAimShot(int count, float speed)
    {
        //If the player is defeated before this barrage, do nothing
        if (player != null)
        {
            // Calculate the position of the player as seen from yourself
            Vector3 diffPosition = player.transform.position - transform.position;
            // Get the angle of the player as seen from yourself
            float angleP = Mathf.Atan2(diffPosition.y, diffPosition.x);

            int bulletCount = count;
            for (int i = 0; i < bulletCount; i++)
            {
                float angle = (i - bulletCount / 2f) * ((Mathf.PI / 2f) / bulletCount); // PI/2f：90


                Shot(angleP + angle, speed);
            }
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        //Bullet _boss
        if (collision.CompareTag("bullet") == true)
        {
            //Boss Hp
            Hp--;


            Destroy(collision.gameObject);

            if (Hp <= 0)
            {
                SCORE.scoreValue += 100;
                //Destroy to get 100 point
                Destroy(gameObject);




            }

        }
    }
}
