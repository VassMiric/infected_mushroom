using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public VisionCone cone;
    public GameObject target;
    public PlayerController player;
    public Rigidbody phys;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        cone = gameObject.GetComponent<VisionCone>();
        target = GameObject.FindGameObjectWithTag("Player");
        phys = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (cone.PlayerVisible)
        {
            //attack
            Vector3 temp = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            Vector3 pos = Vector3.MoveTowards(transform.position, temp, speed * Time.fixedDeltaTime);
            transform.LookAt(target.transform);
            phys.MovePosition(pos);
        }

    }

    private void OnTriggerStay(Collider collide)
    {

        if (collide.transform.tag == "Player" && !player.isAttacking)
        {
            player.DamagePlayer();
        }
    }

}
