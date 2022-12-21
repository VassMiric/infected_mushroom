using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public bool tomb1;
    public bool tomb2;
    public bool tomb3;
    // Start is called before the first frame update
    void Start()
    {
        tomb1 = tomb2 = tomb3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(tomb1 && tomb2 && tomb3)
        {
            Destroy(gameObject);
        }
    }
}
