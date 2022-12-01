using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaknessCone : MonoBehaviour
{
    public float Radius;

    [Range(0,360)]
    public float Angle;

    public GameObject Player;

    public LayerMask Target;
    public LayerMask obstruction;

    public bool PlayerInRange;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(DetectRoutine());
    }

    private void OnEnable() 
    {     
        StartCoroutine(DetectRoutine());
    }

    private IEnumerator DetectRoutine()
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
            Vector3 awayTarget = directionToTarget * -1;

            if (Vector3.Angle(transform.forward, awayTarget) < Angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, awayTarget, distanceToTarget, obstruction))
                {
                    PlayerInRange = true;
                }
                else
                {
                    PlayerInRange = false;
                }
            }
            else
                PlayerInRange = false;
        }
        else if (PlayerInRange)
        {
            PlayerInRange = false;
        }
    }
}
