using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health = 3;
    PlayerController player;
    public VisionCone cone;
    public GameObject target;
    public Rigidbody phys;
    public float speed;
    public Animator animator;
    private float _cooldown = 1.5f;
    private float _refractory = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
            animator.SetBool("Player_Visible", true);
            Vector3 temp = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            Vector3 pos = Vector3.MoveTowards(transform.position, temp, speed * Time.fixedDeltaTime);
            transform.LookAt(target.transform);
            phys.MovePosition(pos);
        }

        if (!cone.PlayerVisible)
        {
            animator.SetBool("Player_Visible", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("boss collision");
        if(health <= 0)
        {
            Destroy(gameObject);
        }

        if (transform.tag == "Player" && player.isAttacking && Time.time > _cooldown)
        {
            health--;
            _cooldown = Time.time + _refractory;
        }

        if (transform.tag == "Player" && !player.isAttacking)
        {
            Debug.Log("boss damage");
            player.DamagePlayer();
        }
   
    }
}
