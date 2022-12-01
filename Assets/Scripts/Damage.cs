using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public int damage = 20;
    public float coolDown = 300.0f;     //issue
    public float timer = 300.0f;        //issue

    public void OnTriggerStay(Collider collision)
    {
        Health H = collision.GetComponent<Health>();

        if (H == null)
        {
            return;
        }

        TakeDamage(H);
    }

    public void TakeDamage(Health H)
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        timer = 0;

        if (timer == 0.0f)
        {
            H.HealthPoints -= damage;
            timer = coolDown;
        }

    }

}
