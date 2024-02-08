using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class rules : MonoBehaviour
{  
    public void Rules ()
    {
        Debug.Log("clicked");
        SceneManager.LoadScene("Scenes/menu" );
    }

}