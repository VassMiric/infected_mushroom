using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    public GameObject gate;
    // Start is called before the first frame update
    void Start()
    {
        gate = GameObject.FindGameObjectWithTag("Gate_One");

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider collide)
    {
        Destroy(gate);
        Destroy(gameObject);
    }
}
