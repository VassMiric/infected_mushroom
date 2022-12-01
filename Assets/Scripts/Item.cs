using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public WorldState1 world;
    public GameObject worldState;
    // Start is called before the first frame update
    void Start()
    {
        worldState = GameObject.Find("WorldState1");
        world = worldState.GetComponent<WorldState1>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pickup()
    {
        world.riverTrigger();
        Destroy (this.gameObject);
    }
}
