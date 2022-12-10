using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{

    public WorldState1 world;
    public PlayerController player;
    public bool action;
    private float _cooldown = 1.5f;
    private float _refractory = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        action = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.getInteract() && action == true && Time.time > _cooldown)
        {
            Debug.Log("Changing World");
            world.triggerToggle();
            _cooldown = Time.time + _refractory;
        }
    }

    private void OnTriggerEnter(Collider collide) 
    {
        if(collide.transform.tag == "Player")
        {
            action = true;
            Rigidbody rbdy = collide.gameObject.GetComponent<Rigidbody>();

            //Stop Moving/Translating
            rbdy.velocity = Vector3.zero;

            //Stop rotating
            rbdy.angularVelocity = Vector3.zero;
        }

    }

    private void OnTriggerExit(Collider collide) 
    {
        action = false;
    }
}
