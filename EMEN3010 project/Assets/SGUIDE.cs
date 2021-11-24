using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SGUIDE : MonoBehaviour

{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            SceneManager.LoadScene("SceneGuide");
        }
    }
}
