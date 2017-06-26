using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrequencyGate : MonoBehaviour
{

    public GameObject LowGate;
    public GameObject HighGate;
    public List<AudioSource> Sources;

    public float HighMax;
    public float HighMin;
    public float LowMin;
    public float LowMax;


    // Use this for initialization
    void Start()
    {
        if (HighGate != null && LowGate != null)
        {
            HighMax = HighGate.transform.position.y;
            HighMin = LowGate.transform.position.y;
            LowMin = HighGate.transform.position.y;
            LowMax = LowGate.transform.position.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HighGate != null && LowGate != null)
        {
            float highCut = 8000 + ((HighGate.transform.position.y - HighMin) / (HighMax - HighMin)) * 6000;
            float lowCut = 80 + ((LowGate.transform.position.y - LowMin) / (LowMax - LowMin)) * 700;
            if (highCut < 8000)
                highCut = 8000;

            if (lowCut < 80)
            {
                lowCut = 80;
            }

            if (lowCut > 1000)
                lowCut = 1000;

            if (highCut > 16000)
                highCut = 16000;

            foreach (AudioSource src in Sources)
            {
                AudioHighPassFilter highPass = src.GetComponent<AudioHighPassFilter>();
                AudioLowPassFilter lowPass = src.GetComponent<AudioLowPassFilter>();
                if (highPass != null)
                    highPass.cutoffFrequency = lowCut;

                if (lowPass != null)
                    lowPass.cutoffFrequency = highCut;
            }
        }
    }
}

