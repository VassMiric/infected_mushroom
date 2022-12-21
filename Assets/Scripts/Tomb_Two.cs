using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomb_Two : MonoBehaviour
{
    public Puzzle puzzle;
    private void OnTriggerEnter(Collider collide)
    {
        if (transform.tag == "Grave_Cross")
        {
            puzzle.tomb2 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (transform.tag == "Grave_Main")
        {
            puzzle.tomb1 = false;
        }
    }
}
