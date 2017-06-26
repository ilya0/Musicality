using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterActivate : MonoBehaviour
{

    public GameObject Effect;
    public AudioSource AudioSrc; 

	// Use this for initialization
	void Start () {
	    if (Effect != null)
	    {
	        Effect.SetActive(false);
	    }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter(Collider other)
    {
        if (AudioSrc)
        {
            AudioSrc.Play();
        }
        if (Effect != null)
        {
            Effect.SetActive(true);
            Debug.Log("Entering "+gameObject.name);
        }
    }

    public void OnTriggerExit()
    {
        if (Effect != null)
        {
            Effect.SetActive(false);
            Debug.Log("Exiting "+gameObject.name);
        }
    }

}
