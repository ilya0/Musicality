using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MakeArray : MonoBehaviour {

    public int ElementsPerSide = 10;
    public int Distance = 10;
    public string ScriptName;
    Vector3 CenterPoint;
    public Color ContactColor = new Color(1, 1, 0);
	// Use this for initialization
	void Start () {

        CenterPoint = transform.position;
        int countx = ElementsPerSide;
        int county = ElementsPerSide;
        int countz = ElementsPerSide;
        for (int x = countx; x>-county; x--)
        {
            for (int y = county; y>-county; y--)
            {
                for (int z = countz; z>-countz; z--)
                {
                    GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    newObject.transform.parent = gameObject.transform;
                    newObject.transform.position = new Vector3(CenterPoint.x+(x*Distance), CenterPoint.y+(y*Distance), CenterPoint.z+(z*Distance));
                    Renderer myRenderer = GetComponent<Renderer>();
                    Renderer newRenderer = newObject.GetComponent<Renderer>();
                    if (myRenderer!=null && newRenderer!=null)
                    {
                        newRenderer.material = myRenderer.material;
                    }

                    if (ScriptName.Length > 0)
                    {
                        newObject.AddComponent(Type.GetType(ScriptName));
                        if (ScriptName=="ReactOnCollision")
                        {
                            ReactOnCollision react = newObject.GetComponent<ReactOnCollision>();
                            react.ContactColor = ContactColor;
                        }
                    }
                }
            }
        }
           	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
