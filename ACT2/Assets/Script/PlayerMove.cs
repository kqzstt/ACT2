using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private CharacterController cc;
    public float speed = 4;
    private Animator animator;

	
    void Awake(){

        animator = this.GetComponent<Animator>();
        cc = this.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //虚拟杆按键操作优先；∨
        if (Joystick.h != 0 || Joystick.v != 0) {
            h = Joystick.h; v = Joystick.v;
        }
        if (Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f)
        {
            animator.SetBool("Walk", true);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerRun"))
            {
                Vector3 targetDir = new Vector3(h, 0, v);
                transform.LookAt(targetDir + transform.position);
                cc.SimpleMove(transform.forward * speed);
            }
        }
        else {
            animator.SetBool("Walk", false);
        }

	}
}
