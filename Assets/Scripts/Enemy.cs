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
    public float health = 2.0f;
    private float _cooldown = 1.5f;
    private float _refractory = 2.5f;
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
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (collide.transform.tag == "Player" && player.isAttacking && Time.time > _cooldown)
        {
            health--;
            _cooldown = Time.time + _refractory;
        }
        else if (collide.transform.tag == "Player" && !player.isAttacking)
        {
            player.DamagePlayer();
        }
    }

    private void OnTriggerEnter(Collider collide)
    {

    }

}
