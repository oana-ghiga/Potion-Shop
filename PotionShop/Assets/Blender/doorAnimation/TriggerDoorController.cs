using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject directinalLight;
    [SerializeField] private GameObject XRInteractionManager;
    [SerializeField] private GameObject Environment;
    [SerializeField] private GameObject HMDInfoManager;
    [SerializeField] private GameObject XRDeviceSimulator;
    [SerializeField] private string sceneName;
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    [SerializeField] private string animationName;

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Player"))
        //{
        Debug.Log("here2");

        if (openTrigger)
            {
                StartCoroutine(OpenDoorAndLoadScene());
            }
            else if (closeTrigger)
            {
                myDoor.Play("CloseDoor", 0, 0.0f);
                //gameObject.SetActive(false);
            }
        //}
    }
    private IEnumerator OpenDoorAndLoadScene()
    {
        Debug.Log("here");
        myDoor.Play(animationName, 0, 0.0f);
        yield return new WaitForSeconds(2.0f);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(directinalLight);
        DontDestroyOnLoad(XRInteractionManager);
        DontDestroyOnLoad(Environment);
        DontDestroyOnLoad(HMDInfoManager);
        DontDestroyOnLoad(XRDeviceSimulator);
        SceneManager.LoadScene(sceneName);
        //gameObject.SetActive(false);
    }
}
