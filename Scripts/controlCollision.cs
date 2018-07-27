using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlCollision : MonoBehaviour {

    
    Animator enemyanimator,playeranimator;
    public GameObject bloodprefab;
    private GameObject destroy;

    void Start()
    {
        playeranimator = GetComponentInParent<Animator>();
    }

	void OnTriggerEnter(Collider col)
    {
       
        if(col.tag == "enemy")
        {
           
            enemyanimator = col.GetComponent<Animator>();
            

            if (playeranimator.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
            {
                destroy = Instantiate(bloodprefab, new Vector3(col.transform.position.x, col.transform.position.y + 1, col.transform.position.z),
                Quaternion.identity);
                destroy.transform.rotation = col.transform.rotation;
            }
           

            if(playeranimator.GetCurrentAnimatorStateInfo(0).IsName("swing") )
            {
                col.GetComponent<agentScript>().zombiehealth -= 25;
                enemyanimator.SetTrigger("hitSwing");
            }
            else if(playeranimator.GetCurrentAnimatorStateInfo(0).IsName("highswing"))
            {
                enemyanimator.SetTrigger("hitHighSwing");
                col.GetComponent<agentScript>().zombiehealth -= 50;

            }
            else if (playeranimator.GetCurrentAnimatorStateInfo(0).IsName("kick"))
            {
                enemyanimator.SetTrigger("isKicked");
                col.GetComponent<agentScript>().zombiehealth -= 10;

            }

            Destroy(destroy, 2f);
        }
    }


}
