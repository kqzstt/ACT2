using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulMonster : MonoBehaviour {

    private Transform player;
    public float attackDistance =1;
    private PlayerATKAndDamage playerATKAndDamage;
    public float speed = 3;
    private CharacterController cc;
    private Animator animator;
    public float attackTime = 3;
    private float attackTimer = 0;
    

	void Start () {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        cc = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
        attackTimer = attackTime;
        playerATKAndDamage = player.GetComponent<PlayerATKAndDamage>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerATKAndDamage.hp <= 0)
        {

            animator.SetBool("Walk", false);
            return;
        }
        
        Vector3 targetPos = player.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);
        float distance = Vector3.Distance(targetPos, transform.position);
        if (distance <= attackDistance)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer > attackTime)
            {
                animator.SetTrigger("Attack");
                attackTimer = 0;
            }
            else {
                animator.SetBool("Walk", false);
            }


        }
        else {
            attackTimer = attackTime;
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("MonRun"))
            {
                cc.SimpleMove(transform.forward * speed);
            }
            animator.SetBool("Walk", true);
        }



		
	}
}
