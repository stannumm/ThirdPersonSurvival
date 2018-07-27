using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontrol : MonoBehaviour {

    
    public Button restart;
    public Text healthhud,youdied; 
    public int playerhealth;
    static Animator animator;
    public static float speed = 2f;
    private float rotationspeed = 75f, rotationwithtime;

    void Start()
    {
        restart.GetComponent<Image>().enabled = false;
        restart.GetComponentInChildren<Text>().enabled = false;
        youdied.enabled = false;
        playerhealth = 100;
        animator = GetComponent<Animator>();
    }
	void Update () {

        float translation = Input.GetAxis("Vertical")*speed;
        float rotation = Input.GetAxis("Horizontal")*rotationspeed;

         rotationwithtime = rotation * Time.deltaTime;
        float translationwithtime = translation * Time.deltaTime;

        if (!animator.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
        {
            transform.Translate(0, 0, translationwithtime);
            transform.Rotate(0, rotationwithtime, 0);
        }
      
        animator.SetFloat("move",translation);

        if (Input.GetButtonDown("Fire1"))
            animator.SetTrigger("swing");
        else if (Input.GetButtonDown("Jump"))
            animator.SetTrigger("kick");
        else if (Input.GetButtonDown("Fire2"))
            animator.SetTrigger("highSwing");

        if (Input.GetButton("sprint") && animator.GetFloat("move") > 0)
        {
            speed = 5f;
            animator.SetBool("isRunning", true);

        }
        else { speed = 2f; animator.SetBool("isRunning",false); }

        animator.SetInteger("health",playerhealth);

        if (playerhealth >= 0)
        healthhud.text = playerhealth.ToString();

        if(playerhealth < 0)
        {
            youdied.enabled = true;
            restart.GetComponent<Image>().enabled = true;
            restart.GetComponentInChildren<Text>().enabled = true;
        }
    }
}
