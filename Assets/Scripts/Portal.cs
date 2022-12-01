using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public WorldState1 world;
    public PlayerController player;
    public bool action;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        action = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.getInteract() && action == true)
        {
            player.transform.position = target.position;
        }
    }

    private void OnTriggerEnter(Collider collide) 
    {
        if(collide.transform.tag == "Player")
        {
            action = true;
        }
    }

    private void OnTriggerExit(Collider collide) 
    {
        action = false;
    }
}
