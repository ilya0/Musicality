using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public float Speed = 4f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float ang = transform.localEulerAngles.z;
        float angx = transform.localEulerAngles.x;
        float angy = transform.localEulerAngles.y;
        ang += Speed * Time.deltaTime;
        transform.localEulerAngles = new Vector3(angx, angy, ang);
    }
}
