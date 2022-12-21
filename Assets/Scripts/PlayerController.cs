using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float turnSpeed = 9000;
    private Vector3 input;
    private Vector3 slideDir;
    private float slideSpeed;
    private State state;

    public bool isWalking;
    public bool isDodging;
    public bool isRunning;
    public bool isInteracting;
    public bool isAttacking;
    public bool isDead;

    public int maxHealth = 100;
    public int currenthealth;
    public int damage = 10;

    public float attackDur;
    public Animator anim;
    private enum State
    {
        normal,
        sliding,
        attacking,
        dead,
    }

    [SerializeField]
    private GameObject gameOverUI;

    private float _cooldown = 1.5f;
    private float _refractory = 3.0f;
    public HealthBar healthBar;

    private void Start() {


        currenthealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currenthealth);
        state = State.normal;
        isWalking = false;
        isDodging = false;
        isRunning = false;
        isInteracting = false;
        isAttacking = false;
        isDead = false;
        anim = GetComponent<Animator>();
    }

    void Update() 
    {
        switch (state)
        {
            case State.normal:
                bool roll = Input.GetKeyDown(KeyCode.Space);
                GatherInput();
                Look();
                HandleRoll(roll);
                HandleAttack();
                HandleInteract();
                break;
            case State.attacking:
                HandleAttacking();
                break;
            case State.sliding:
                HandleSliding();
                break;
            case State.dead:
                isDead = true;
                PlayerDead();
                break;
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void GatherInput()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void Move()
    {
        rb.MovePosition(transform.position +(transform.forward * input.magnitude) * speed * Time.deltaTime);
    }

    public string getState()
    {
        return state.ToString();
    }

    public bool getInteract()
    {
        return isInteracting;
    }

    public void killPlayer()
    {
        state = State.dead;
        anim.SetBool("isDead", true);
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    void Look()
    {
        if(input != Vector3.zero)
        {
            isWalking = true;
            anim.SetBool("isWalking", true);
            var relative = (transform.position + input.ToIso()) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
            slideDir = relative;
        }
        else
        {
            anim.SetBool("isWalking", false);
            isWalking = false;
        }
    }

    void HandleRoll(bool roll)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isDodging", true);
            state = State.sliding;
            slideSpeed = 20f;
        }
    }

    void PlayerDead()
    {
        isDead = true;
        Debug.Log("Player is currently Dead");
    }

    void HandleSliding()
    {
        isDodging = true;

        transform.position += slideDir * slideSpeed * Time.deltaTime;

        slideSpeed -= slideSpeed * 5f * Time.deltaTime;

        if(slideSpeed < 2f)
        {
            state = State.normal;
            isDodging = false;
            anim.SetBool("isDodging", false);
        }
    }

    void HandleAttack()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            anim.SetBool("isAttacking", true);
            state = State.attacking;
            attackDur = 200.0f;
            Debug.Log("Attack Start!");
        }
    }

    void HandleAttacking()
    {
        attackDur -= 2.0f;
        isAttacking = true;
        if(attackDur < 1.0f)
        {
            anim.SetBool("isAttacking", false);
            isAttacking = false;
            state = State.normal;
            Debug.Log("Attack end");
        }
    }

    void HandleInteract()
    {
        if(Input.GetKeyDown("e"))
        {
            isInteracting = true;
            anim.SetBool("isInteracting", true);
        }
        else if(Input.GetKeyUp("e"))
        {
            isInteracting = false;
            anim.SetBool("isInteracting", false);
        }
    }

    public void DamagePlayer()
    {
        if(currenthealth <= 0)
        {
            state = State.dead;
            gameOverUI.SetActive(true);
        }
        else
        {
            if(Time.time > _cooldown)
            {
                Debug.Log("success");
                currenthealth -= damage;
                int newHealth = (int)currenthealth;
                healthBar.SetHealth(newHealth);
                _cooldown = Time.time + _refractory;
            }
        }
    }


}
