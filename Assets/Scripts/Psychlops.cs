using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Psychlops : MonoBehaviour
{

    public Transform[] target;  
    public float speed;  
    private int current;
    public VisionCone cone;
    public PlayerChase chase;
    public GameObject player;
    public weaknessCone weak;
    public GameObject dropArea; 

    public GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        cone = this.gameObject.GetComponent<VisionCone>();
        weak = this.gameObject.GetComponent<weaknessCone>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
         if(chase.PlayerVisible)
         {
            Vector3 pos = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            Vector3 targetDirection = player.transform.position - transform.position;
            float singleStep = speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            Debug.DrawRay(transform.position, newDirection, Color.red);
            transform.rotation = Quaternion.LookRotation(newDirection);
            GetComponent < Rigidbody > ().MovePosition(pos);  
         }
         else if (transform.position != target[current].position) 
         {  
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            Vector3 targetDirection = target[current].position - transform.position;
            float singleStep = speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            Debug.DrawRay(transform.position, newDirection, Color.red);
            transform.rotation = Quaternion.LookRotation(newDirection);
            GetComponent < Rigidbody > ().MovePosition(pos);
        } 
        else current = (current + 1) % target.Length;

        if(cone.PlayerVisible)
        {
            Health playerhp = player.GetComponent<Health>();
            playerhp.takeSanityDamage();
        }

        if(weak.PlayerInRange)
        {
            handlePlayer();
        }
        
    } 

    void handlePlayer()
    {
        PlayerController play = player.GetComponent<PlayerController>();
        Debug.Log(play.getState());
        if(play.getState() == "attacking")
        {
            Vector3 newVec = new Vector3(transform.position.x, -3, transform.position.z);
            GameObject baby = Instantiate(item, newVec, dropArea.transform.rotation);
            Destroy (this.gameObject);
        }
    }
    
}
