 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    GameObject player;
    public bossbullet bulletPrefab;
    int Hp = 10;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("plane-removebg-preview");
        StartCoroutine(CPU());
    }
    void Shot(float angle, float speed)
    {
        bossbullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.Setting(angle, speed); // Mathf.PI/4fは45°
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
            yield return new WaitForSeconds(3f);
            yield return WaveNShotMCurve(4, 16);
            yield return new WaitForSeconds(3f);
            yield return WaveNPlayerAimShot(4, 6);
            yield return new WaitForSeconds(1f);
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
        // 4回8方向に撃ちたい
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
        //この弾幕前にplayerが倒されていたら何もしない
        if (player != null)
        {
            // 自分からみたPlayerの位置を計算する
            Vector3 diffPosition = player.transform.position - transform.position;
            // 自分から見たPlayerの角度を出す：傾きから角度を出す：アークタンジェントを使う
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

        //BulletとBossが接触した時
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
    
