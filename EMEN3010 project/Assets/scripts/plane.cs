  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class plane : MonoBehaviour
{
    Rigidbody2D plane1;
    float speed = 4500.0f;
    Vector2 worldPosLeftBottom;
    Vector2 worldPosTopRight;
    public GameObject bulletPrefab;
    public static float px = 0;
    public static float py = 0;
    AudioSource audioSource;//audiosource
    public AudioClip shotSE;//SE
    // Start is called before the first frame update
    void Start()
    {
        plane1 = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(shotSE);
        }
        //
        px = transform.position.x * 0.7f;
        py = transform.position.y * 0.7f;



    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Gameover");
        SceneManager.LoadScene("SceneGameover");
        return;
        
     }
    //end the game while crash
    
    

}


