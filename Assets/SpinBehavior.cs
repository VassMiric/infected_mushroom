using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinBehavior : StateMachineBehaviour
{
    //public float timer;
    //public float mintime;
    //public float maxtime;

    //private Transform player;
    //public float speed;

    //// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    //    timer = Random.Range(mintime, maxtime);
    //}

    //// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    if (timer <= 0)
    //    {
    //        animator.SetTrigger("idle_Battle_SwordAndShield");
    //    }
    //    else
    //    {
    //        timer -= Time.deltaTime;
    //    }
    //    Vector3 temp = new Vector3(player.transform.position.x, animator.transform.position.y, player.transform.position.z);
    //    animator.transform.position = Vector3.MoveTowards(animator.transform.position, temp, speed * Time.fixedDeltaTime);
    //}

    //// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
