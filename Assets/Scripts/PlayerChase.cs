using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChase : MonoBehaviour
{
 public float Radius;

    [Range(0,360)]
    public float Angle;

    public GameObject Player;

    public LayerMask Target;
    public LayerMask obstruction;

    public bool PlayerVisible;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(ChaseRoutine());
    }

    private void Update() 
    {
    }

    private void OnEnable() 
    {     
        StartCoroutine(ChaseRoutine());
    }

    private IEnumerator ChaseRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, Radius, Target);
        if(rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < Angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstruction))
                {
                    PlayerVisible = true;
                }
                else
                {
                    PlayerVisible = false;
                }
            }
            else
                PlayerVisible = false;
        }
        else if (PlayerVisible)
        {
            PlayerVisible = false;
        }
    }
}
