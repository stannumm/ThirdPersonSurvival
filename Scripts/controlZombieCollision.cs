using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlZombieCollision : MonoBehaviour {


    public GameObject bloodprefab;
    private GameObject destroy;
    private Animator animator;
    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }
	void OnTriggerEnter (Collider col) {
        
      
        if (col.tag == "Player")
        {
            destroy = Instantiate(bloodprefab, new Vector3(col.transform.position.x, col.transform.position.y + 1, col.transform.position.z),
                Quaternion.identity);
            destroy.transform.rotation = col.transform.rotation;
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
            col.GetComponentInChildren<playercontrol>().playerhealth -= 10;
            
        }
        Destroy(destroy, 2f);
    }
    
}
