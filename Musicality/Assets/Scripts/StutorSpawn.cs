using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StutorSpawn : MonoBehaviour
{

    public float Delay = 0.5f;
    public float FadeSpeed = 6;
    public float GrowSpeed = 0.5f;
    public float DelayCount;
    public Material TransparentMaterial;
    Renderer MyRenderer;

    // Use this for initialization
    void Start()
    {
        MyRenderer = GetComponent<Renderer>();
        DelayCount = Delay;

    }

    // Update is called once per frame
    void Update()
    {
        if (DelayCount > 0)
        {
            DelayCount -= Time.deltaTime;

        }
        else
        {
            DelayCount = Delay;
            SpawnCube();
        }
    }

    void SpawnCube()
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
                    0.33f);
            }

            newCube.AddComponent<ExpandAndFadeOut>();
            var expander = newCube.GetComponent<ExpandAndFadeOut>();
            if (expander != null)
            {
                expander.GrowSpeed = GrowSpeed;
                expander.FadeSpeed = FadeSpeed;
            }
        }
    }
}
