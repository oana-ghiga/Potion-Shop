using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowObject : MonoBehaviour
{
    public float throwForce = 10f;
    public float throwUpwardForce = 5f;
    private Vector3 objectPos;
    private float distance;
    private bool isGrabbed = false;
    public Text scoreText; 
    void Start()
    {
      
    }

    void Update()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            if (grabInteractable.isSelected)
            {
                isGrabbed = true;
                distance = Vector3.Distance(transform.position, Camera.main.transform.position);
                objectPos = transform.position;
            }
            else
            {
                if (isGrabbed && Input.GetKeyUp(KeyCode.G))
                {
                    Vector3 throwDirection = Camera.main.transform.forward;
                    Rigidbody rb = GetComponent<Rigidbody>();
                    rb.AddForce(throwDirection * throwForce + Vector3.up * throwUpwardForce, ForceMode.Impulse);
                }

                isGrabbed = false;
            }
        }
        else
        {
            Debug.LogError("XRGrabInteractable component not found on object: " + gameObject.name);
        }
    }

}