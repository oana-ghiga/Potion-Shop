using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class menu : MonoBehaviour
{  
    public void Startgame ()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene("Scenes/inside");
    }

    public void Rules ()
    {
        Debug.Log("Rules");
        SceneManager.LoadScene("Scenes/rules");
    }

    public void Quit()
    {   
        Debug.Log("Quit");
        Application.Quit();
    }
}