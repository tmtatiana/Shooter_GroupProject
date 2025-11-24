using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Game");
        }
        */
    }

    public void PlayGame()
    {
        // Should text be "Tatiana" to match my scene?
        SceneManager.LoadScene("Game");
    }
}
