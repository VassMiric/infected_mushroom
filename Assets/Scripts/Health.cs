using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int StartingHealth = 10000;
    public PlayerController player;
    public WorldState1 world;
    private bool isDead;
   
    public int HealthPoints
    {
        get { return _health; }

        set
        {
            _health = value;

            if(_health <= 0 && !isDead)
            {
                Debug.Log("You're dead!");
                isDead = true;
                player.killPlayer();
                StartCoroutine(WorldRestart());
            }
        }
    }

    private IEnumerator WorldRestart()
    {
        Debug.Log("waiting for Respawn");
        yield return new WaitForSecondsRealtime(3);
        world.sceneReset();
    }

    public int _health;

    // Start is called before the first frame update
    void Start()
    {
        HealthPoints = StartingHealth;
        isDead = false;
        player = gameObject.GetComponent<PlayerController>();
    }




}
