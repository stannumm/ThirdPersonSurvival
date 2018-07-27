using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agentScript : MonoBehaviour {

    public Transform player;
    NavMeshAgent agent;
    Animator animator;
    float distance;
    public int zombiehealth;

    void Start () {
        agent = transform.GetComponent<NavMeshAgent>();
        animator = transform.GetComponent<Animator>();
        player = GameObject.Find("player").GetComponent<Transform>();
        zombiehealth = 100;
    }
	

	void Update () {
        
        animator.SetFloat("moveSpeed", Mathf.Abs(agent.velocity.z));  
        agent.SetDestination(player.transform.position);

        if (agent.remainingDistance < 2 && agent.remainingDistance != 0) //distance 0 başlıyo direk attack animasyonu çalışıyo
        {
            agent.Stop();
            animator.SetBool("isMoving", false);
            animator.SetBool("attack",true);
        }
        else
        {
            animator.SetBool("attack", false);
            agent.Resume();
            animator.SetBool("isMoving", true);
        }
        animator.SetInteger("health",zombiehealth);

        if (zombiehealth<0)
            Destroy(this.gameObject,5f);
    }
}
