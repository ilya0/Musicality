using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;



public class ExpandAndFadeOut : MonoBehaviour {

    public float GrowSpeed = 1;
    public float FadeSpeed = 0.1111f;
    public float FadeMult = 1;


    public bool IsActivated = false;
    public float CurrentGrowCount = 1;
    public float CurrentFadeCount = 0.96f;

    private Renderer MyRenderer;
    private Color BaseColor;
    private Vector3 BaseScale = new Vector3(1, 1, 1);
    

	// Use this for initialization
	void Start () {
        if (FadeSpeed != 0.0f)
        {
            FadeMult = 1 - (0.01f * FadeSpeed);
        }
		if (transform != null)
        {
            BaseScale = transform.localScale;
        }

        MyRenderer = GetComponent<Renderer>();
        if (MyRenderer != null)
        {
            BaseColor = MyRenderer.material.color;
        }
        
	}

    public void OnEnable()
    {
        CurrentFadeCount = 0.96f;
        CurrentGrowCount = 1;
        IsActivated = true;
    }

    void ResetToStart()
    {
        if (transform != null)
        {
            transform.localScale = BaseScale;
        }

        if (MyRenderer != null)
        {
            MyRenderer.material.color = BaseColor;
        }
        IsActivated = false;
        gameObject.SetActive(false);
    }

	// Update is called once per frame
    void Update()
    {

        if (IsActivated)
        {
            CurrentFadeCount -= Time.deltaTime * FadeSpeed;
            if (CurrentFadeCount < 0)
            {
                CurrentFadeCount = 0;
                //GameObject.Destroy(gameObject);
                ResetToStart();

            }

            CurrentGrowCount += Time.deltaTime * GrowSpeed;
            Vector3 newScale = new Vector3(BaseScale.x * CurrentGrowCount, BaseScale.y * CurrentGrowCount,
                BaseScale.z * CurrentGrowCount);
            transform.localScale = newScale;

            Color newColor = new Color(BaseColor.r, BaseColor.g, BaseColor.b * (2.0f - CurrentFadeCount),
                BaseColor.a * (CurrentFadeCount));
            if (MyRenderer != null)
            {
                MyRenderer.material.color = newColor;
            }
        }
    }
}
