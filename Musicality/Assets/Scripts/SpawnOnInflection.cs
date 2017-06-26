using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnInflection : MonoBehaviour {

    public Vector3 OldScale = new Vector3(1, 1, 1);
    public bool IsGrowing = false;
    public Material TransparentMaterial;
    Renderer MyRenderer;

	// Use this for initialization
	void Start () {
        MyRenderer = GetComponent<Renderer>();
        OldScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (OldScale.x < transform.localScale.x)
        {
            IsGrowing = true;
        }

		if (IsGrowing && OldScale.x > transform.localScale.x)
        {
            IsGrowing = false;

             SpawnClone();
        }

        OldScale = transform.localScale;
	}
    private void SpawnClone()
    {
        GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        if (newCube != null && newCube.transform != null)
        {
            newCube.transform.position = transform.position;
            newCube.transform.localScale = transform.localScale;
            newCube.transform.rotation = transform.rotation;
            Renderer newRenderer = newCube.GetComponent<Renderer>();
            if (newRenderer != null && MyRenderer != null)
            {
                if (TransparentMaterial != null)
                {
                    newRenderer.material = TransparentMaterial;
                }
                newRenderer.material.color = new Color(MyRenderer.material.color.r,
                    MyRenderer.material.color.g, MyRenderer.material.color.b,
                    0.43f);
            }

            newCube.AddComponent<ExpandAndFadeOut>();

        }
    }
}
