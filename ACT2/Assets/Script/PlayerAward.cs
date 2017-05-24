using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAward : MonoBehaviour {
    public GameObject singleSwordGo;
    public GameObject dualSwordGO;
    public GameObject gunGo;
    public float exitTime=10;
    public float GunTimer = 0;
    public float DualSwordTimer = 0;

    void Update()
    {
        if (DualSwordTimer > 0)
        {
            DualSwordTimer -= Time.deltaTime;
            if (DualSwordTimer < 0)
            {
                TurnToSingleSword();
            }
        }
        if (GunTimer > 0)
        {
            GunTimer -= Time.deltaTime;
            if (GunTimer < 0)
            {
                TurnToSingleSword();
            }
        }
    }
    
    public void GetAward(AwardType type)
    {
        if (type == AwardType.DualSword)
        {
            TurnToDualSword();
        }else if(type == AwardType.Gun)
        {
            TurnTGun();
        }
    }
    void TurnToDualSword()
    {
        singleSwordGo.SetActive(false);
        dualSwordGO.SetActive(true);
        gunGo.SetActive(false);
        GunTimer = 0;
        DualSwordTimer = exitTime;
        UIAttack._instance.TurnToTwoAttack();
    }
    void TurnTGun()
    {
        singleSwordGo.SetActive(false);
        dualSwordGO.SetActive(false);
        gunGo.SetActive(true);
        GunTimer = exitTime;
        DualSwordTimer = 0;
        UIAttack._instance.TurnToOneAttack();

    }
    void TurnToSingleSword()
    {
        singleSwordGo.SetActive(true);
        dualSwordGO.SetActive(false);
        gunGo.SetActive(false);
        GunTimer = 0;
        DualSwordTimer = 0;
        UIAttack._instance.TurnToTwoAttack();
    }



}


