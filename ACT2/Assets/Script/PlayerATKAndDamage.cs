using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerATKAndDamage : ATKAndDamage {
    public float attackB = 80;
    public float attackRange = 100;
    public WeaponGun gun;
    public AudioClip GunClip;
    public AudioClip AttackClip;
    
    
    public void AttackA() { 
       GameObject enemy = null;
        float distance = attackDistance;
        foreach (GameObject go in SpawnManager._instance.enemyList)
        {
            float temp=Vector3.Distance(go.transform.position, transform.position);
            if (temp < distance)
            {
                enemy = go;
                distance = temp;
            }

            }
        if (enemy != null)
        {
            Vector3 targetPos = enemy.transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
            enemy.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);
        }

    }
    public void AttackB()
    {
        AudioSource.PlayClipAtPoint(AttackClip, transform.position, 1f);
        GameObject enemy = null;
        float distance = attackDistance;
        foreach (GameObject go in SpawnManager._instance.enemyList)
        {
            float temp = Vector3.Distance(go.transform.position, transform.position);
            if (temp < distance)
            {
                enemy = go;
                distance = temp;
            }

        }
        if (enemy != null)
        {
            Vector3 targetPos = enemy.transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
            enemy.GetComponent<ATKAndDamage>().TakeDamage(attackB);
        }
    }
    public void AttackRange()
    {

        AudioSource.PlayClipAtPoint(AttackClip, transform.position, 1f);
        List<GameObject> enemyList = new List<GameObject>();
  
        foreach (GameObject go in SpawnManager._instance.enemyList)
        {
            float temp = Vector3.Distance(go.transform.position, transform.position);
            if (temp < attackDistance)
            {
                enemyList.Add(go);
                //go.GetComponent<ATKAndDamage>().TakeDamage(attackRange);
                
            }

        }
        foreach (GameObject go in enemyList)
        {
            go.GetComponent<ATKAndDamage>().TakeDamage(attackRange);
        }
    }
    public void AttackGun()
    {
        gun.Shot();
        AudioSource.PlayClipAtPoint(GunClip, transform.position, 1f);
    }
}
