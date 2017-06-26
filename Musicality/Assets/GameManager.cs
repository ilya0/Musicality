using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<AudioSource> audioList;
    public GameObject SpatialPro;
    public Camera camera;
    private SpaceCollectionManager scm;

    public List<float> Distance;

    public List<float> MaxDistance;

    public List<Vector3> InitScale;

    public List<float> Param;

    public List<float> Scale;

    // Use this for initialization
    void Start()
    {
        scm = GetComponent<SpaceCollectionManager>();
        if (scm != null)


        {
            foreach (var marker in scm.spaceObjectPrefabs)
            {
                Distance.Add(0);
                MaxDistance.Add(Vector3.Distance(camera.transform.position, scm.spaceObjectPrefabs[0].transform.position));
                InitScale.Add(marker.transform.localScale);
                Param.Add(0);
            }

        }


    }


    // Update is called once per frame
    void Update()
    {

        if (scm != null)
        {
            if (scm.spaceObjectPrefabs.Count > 1)
            {
                for (int x = 0; x < scm.spaceObjectPrefabs.Count; x++)
                {
                    if (scm.spaceObjectPrefabs[x].transform.position == Vector3.zero)
                    {
                        scm.spaceObjectPrefabs[x].transform.Translate(Random.Range(-5f,5f),0,Random.Range(-5f,5f));
                    }
                    Distance[x] =

                        Vector3.Distance(camera.transform.position, scm.spaceObjectPrefabs[x].transform.position);
                    if (MaxDistance[x] < Distance[x])
                        MaxDistance[x] = Distance[x];


                    float scaler = 1f;

                    if (x < Scale.Count)
                        scaler = Scale[x];

                    Param[x] = scaler * Distance[x] / MaxDistance[x];


                }


                //  if (audioList.Count > 1 && Param.Count > 1 )
                //  {
                //      audioList[0].volume = Param[0];
                //    audioList[1].volume = 1f - Param[0];
                //   }




                for (int x = 0; x < audioList.Count; x++)
                {
                    if (Param.Count > x)
                    {
                        audioList[x].volume = Param[x];
                        if (InitScale.Count > x)
                        {
                            scm.spaceObjectPrefabs[x].transform.localScale = new Vector3(InitScale[x].x*Param[x],
                                InitScale[x].y*Param[x], InitScale[x].z*Param[x]);
                        }

                    }

                }
                //    foreach (var audsrc in audioList)
                //    {

                // if 

                //        AudioChorusFilter chorus = audsrc.GetComponent<AudioChorusFilter>();
                //        if (audsrc && Param.Count > 1)
                //        {
                //            chorus.wetMix1 = 1f-Param[1];
                //           chorus.wetMix2 = 1f-Param[1];
                //           chorus.wetMix3 = 1f-Param[1];
                //       }
                //}


                //    foreach (var audsrc in audioList)
                //   {
                //       AudioHighPassFilter filter = audsrc.GetComponent<AudioHighPassFilter>();
                //       if (audsrc && Param.Count > 2)
                //       {
                //           filter.cutoffFrequency = 4000f - Param[2] * 3000f;
                //       }
                //   }

            }

        }
    }
}
