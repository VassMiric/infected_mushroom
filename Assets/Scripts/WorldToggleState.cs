using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldToggleState : MonoBehaviour
{
    public bool psychadelic = false;
    private GameObject[] normObjects;
    private GameObject[] psychObjects;

    // Start is called before the first frame update
    void Start()
    {
        normObjects = GameObject.FindGameObjectsWithTag("normal_world");
        psychObjects = GameObject.FindGameObjectsWithTag("psych_world");
    }

    // Update is called once per frame
    void Update()
    {
        //only update when something changes

            if (psychadelic)
            {
                hideNormal();
            }
            else
            {
                hidePsychadellic();
            }

    }

    //hide psych make normal visible
    void hidePsychadellic()
    {

        foreach (GameObject obj in psychObjects)
        {
            obj.active = false;
        }

        foreach (GameObject obj in normObjects)
        {
            obj.active = true;
        }

    }


    //hide normal world, make psych visible
    void hideNormal()
    {

        foreach (GameObject obj in psychObjects)
        {
            obj.active = true;
        }

        foreach (GameObject obj in normObjects)
        {
            obj.active = false;
        }
    }

    public  void triggerPsychadelic()
    {
        if(psychadelic)
        {
            psychadelic = false;
        }
        else
        {
            psychadelic = true;
        }
    }

    public bool getPsychState()
    {
        return psychadelic;
    }
}
