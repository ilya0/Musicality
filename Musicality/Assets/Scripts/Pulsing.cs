using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsing : MonoBehaviour {


    public Vector3 BaseScale = new Vector3(1, 1, 1);
    public bool MakeMusic = true;
    public float Speed = 1f;
    public bool RandomizeSpeed = true;
    public float RotationSpeed = 1f;
    public Light Strober;

    public List <AudioSource> Chords;
    
    public int CurrentChord = 0;
     
    public float ScaleFactor = 0.5f;
    public float direction = -1;
    public float CurrentCount = 0;
    public float CurrentSin = 0f;
    public float nextTarget = 360;
    public float CurrentRotation = 0f;

    int FCount = 0;
    int CCount =0;
    Renderer MyRenderer;

	// Use this for initialization
	void Start () {
        MyRenderer = GetComponent<Renderer>();
        BaseScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
     

        CurrentRotation += ( Random.value * RotationSpeed * Time.deltaTime  );
        CurrentCount += Speed * Time.deltaTime;
        CurrentSin = Mathf.Sin(CurrentCount);
        float OldDirection = direction;

        if (CurrentSin < 0)
            direction = -1f;
        else
            direction = 1f;

        if (OldDirection != direction  && direction == -1f)
        {
            if (MakeMusic && Chords.Count > 0)
            {
                PlayMusic();
            }
        }

        Color newColor = new Color(1-CurrentSin,CurrentSin, 1);
        if (MyRenderer!=null)
        {
            MyRenderer.material.color = newColor;  
        }
        float xScale = BaseScale.x + (BaseScale.x * CurrentSin * ScaleFactor);
        float yScale = BaseScale.y + (BaseScale.y * CurrentSin * ScaleFactor);
        float zScale = BaseScale.z + (BaseScale.z * CurrentSin * ScaleFactor);


        if ((Random.value < 0.004f ) && RandomizeSpeed)
        {
            if (Random.value > 0.5f)
            {
                Speed+= 1;
            }
            else
                 Speed-=1;

            if (Speed < 5.0f)
                Speed = 7.0f;

            if (Speed > 12)
            {
                Speed = 12f;
            }

        }

        transform.localEulerAngles = new Vector3(0, CurrentRotation, 0);
        transform.localScale = new Vector3(xScale, yScale, zScale);
       if (Strober != null)
        {
            Strober.intensity = CurrentSin * 2f;
        }
        
       }

    void PlayMusic()
    {
        switch (Chords.Count)

        {
            case 1:
                Chords[0].Play();
                break;
            case 2:
                CurrentChord = Random.Range(0, Chords.Count);
                break;
             case 3:
                switch (CurrentChord)
                {
                    case 0:
                        CCount++;
                        FCount = 0;
                        if (CCount > 4)
                        {
                            CurrentChord = Random.Range(1, Chords.Count);
                        }
                        else
                        {
                            if (Random.value > 0.25)
                                CurrentChord = 0;
                            else
                            {
                                if (Random.value > 0.42)
                                    CurrentChord = 1;
                                else
                                    CurrentChord = Random.Range(1, Chords.Count);
                            }
                        }
                            break;
                case 1:
                        CCount = 0;
                        FCount++;
                        if (FCount > 1)
                        {
                            CurrentChord = 0;
                        }
                        else
                        {
                            if (Random.value > 0.27)
                            {
                                if (Random.value < 0.40)
                                    CurrentChord = Random.Range(0, Chords.Count);
                                else
                                    CurrentChord = Random.Range(0, Chords.Count - 1);
                            }
                        }
                        break;

                    case 2:
                        FCount = 0;
                        CCount = 0;
                        if (Random.value > .10)
                            CurrentChord = Random.Range(0,Chords.Count);
                        break;

                }
                Chords[CurrentChord].Play();

                break;
        }
    }
}
