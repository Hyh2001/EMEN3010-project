using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClearDirector : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("return"))
        {
            SCORE.scoreValue = 0;
            SceneManager.LoadScene("scene1");
        }
    }
}
