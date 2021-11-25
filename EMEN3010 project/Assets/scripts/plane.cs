  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class plane : MonoBehaviour
{
    Rigidbody2D plane1;
    float speed = 5000.0f;
    Vector2 worldPosLeftBottom;
    Vector2 worldPosTopRight;
    public GameObject bulletPrefab;
    public static float px = 0;//自機位置ｘ外部ファイル参照用
    public static float py = 0;//自機位置ｙ外部ファイル参照用
    // Start is called before the first frame update
    void Start()
    {
        plane1 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // the first part is the control of motion:
        // using arrows to control
        // the range of moving is confined to the maincamera
        // and there is a delfection to make sure that the whole plane is inside the screen


        worldPosLeftBottom = Camera.main.ViewportToWorldPoint(Vector2.zero);
        worldPosTopRight = Camera.main.ViewportToWorldPoint(Vector2.one);
        int direction = 0;
        float deflect = 0.6f;
        if (Input.GetKey(KeyCode.RightArrow))
        {   
            direction = 1;
            plane1.AddForce(transform.right * direction * speed);
            //      plane1.velocity.x = direction * speed;

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1;
            plane1.AddForce(transform.right * direction * speed);
            //          plane1.velocity.x = direction * speed;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = 1;
            plane1.AddForce(transform.up * direction * speed);
            //      plane1.velocity.x = direction * speed;

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = -1;
            plane1.AddForce(transform.up * direction * speed);
            //      plane1.velocity.x = direction * speed;

        }
        plane1.velocity = Vector2.zero;
        plane1.position = new Vector2(Mathf.Clamp(plane1.position.x, worldPosLeftBottom.x + deflect, worldPosTopRight.x - deflect), Mathf.Clamp(plane1.position.y, worldPosLeftBottom.y + deflect, worldPosTopRight.y - deflect));
        /*        if (Input.GetKeyUp(KeyCode.RightArrow || KeyCode.LeftArrow || KeyCode.UpArrow ||  KeyCode.DownArrow))
                {

                    plane1.velocity = Vector2.zero;
                }*/


        // the second part will be shoot bullets out




        

     
        if (Input.GetKeyDown("z"))
       {
          Instantiate(bulletPrefab, transform.position, Quaternion.identity);
       }
        px = transform.position.x * 0.7f;//自機狙い弾用
        py = transform.position.y * 0.7f;//自機狙い弾用



    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Gameover");
        SceneManager.LoadScene("SceneGameover");
        return;
        
     }
    //end the game while crash
    
    

}


