using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlock : MonoBehaviour
{

    public bool movableInPsy;
    public Rigidbody rb;
    public WorldToggleState toggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movableInPsy && toggle.getPsychState())
        {
            rb.constraints = RigidbodyConstraints.None;
        }
        else if(!movableInPsy && !toggle.getPsychState())
        {
            rb.constraints = RigidbodyConstraints.None;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
