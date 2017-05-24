using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationAttack : MonoBehaviour {


    private Animator animator;
    private bool isCanAttackB = false;
    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
        EventDelegate NormalAttackEvent = new EventDelegate(this, "OnNormalAttackClick");
        GameObject.Find("NormalAttack").GetComponent<UIButton>().onClick.Add(NormalAttackEvent);

        EventDelegate RangeAttackEvent = new EventDelegate(this, "OnRangeAttackClick");
        GameObject.Find("RangeAttack").GetComponent<UIButton>().onClick.Add(RangeAttackEvent);

        EventDelegate RedAttackEvent = new EventDelegate(this, "OnRedAttackClick");
        GameObject redAttack = GameObject.Find("RedAttack");
        redAttack.GetComponent<UIButton>().onClick.Add(RedAttackEvent);//添加事件监听，
        redAttack.SetActive(false);//设置默认禁止
    }

	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnNormalAttackClick() {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackA") && isCanAttackB)
        {
            animator.SetTrigger("Attack B");
        }
        else
        {
            animator.SetTrigger("Attack A");
        }
    }
    public void OnRangeAttackClick()
    {
        animator.SetTrigger("Attack Range");
    }
    public void OnRedAttackClick() {
        animator.SetTrigger("Attack Gun");
    }
    public void AttackBEvent1()
    {
        isCanAttackB = true;
    
    }
    public void AttackBEvent2()
    {
        isCanAttackB = false;
    }

}
