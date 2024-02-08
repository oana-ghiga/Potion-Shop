using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerCartController : MonoBehaviour
{
    [SerializeField] private GameObject directinalLight;
    [SerializeField] private GameObject XRInteractionManager;
    [SerializeField] private GameObject Environment;
    [SerializeField] private GameObject HMDInfoManager;
    [SerializeField] private GameObject XRDeviceSimulator;
    [SerializeField] private string sceneName;



    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(OpenDoorAndLoadScene());   
    }
    private IEnumerator OpenDoorAndLoadScene()
    {
        yield return new WaitForSeconds(2.0f);
        DontDestroyOnLoad(directinalLight);
        DontDestroyOnLoad(XRInteractionManager);
        DontDestroyOnLoad(Environment);
        DontDestroyOnLoad(HMDInfoManager);
        DontDestroyOnLoad(XRDeviceSimulator);
        SceneManager.LoadScene(sceneName);
    }
}
