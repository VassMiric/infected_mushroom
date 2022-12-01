using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollide : MonoBehaviour
{
    public GameObject thing;
    public Item item;
    public bool action;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        item = thing.GetComponent<Item>();
        action = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.getInteract())
        {
            if (action == true)
            {
                action = false;
                item.pickup();
                Destroy (this.gameObject);
            }
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
