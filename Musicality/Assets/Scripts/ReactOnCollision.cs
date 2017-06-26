using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactOnCollision : MonoBehaviour {

    public Color ContactColor = new Color(0.5f, 0f, 0f, 0.5f);
    private Color oldColor = new Color(1f,1f,1f);
    Collider myCollider;
    Renderer myRenderer;

	// Use this for initialization
	void Start () {
        myRenderer = GetComponent<Renderer>();
        myCollider = gameObject.GetComponent<Collider>();
        myCollider.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        SpawnClone();
        if (myRenderer != null)
            myRenderer.material.color = ContactColor;
    }

    void OnTriggerExit()
    {
        if (myRenderer != null && oldColor != null)
            myRenderer.material.color = oldColor;
    }

    void SpawnClone()
    {
        GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        newObject.transform.parent = gameObject.transform;
        newObject.transform.position = transform.position;
        newObject.transform.localScale = transform.localScale;
        Renderer newRenderer = newObject.GetComponent<Renderer>();
        if (myRenderer != null && newRenderer != null)
        {
            newRenderer.material = myRenderer.material;
        }

        newObject.AddComponent<ExpandAndFadeOut>();

    }
}
