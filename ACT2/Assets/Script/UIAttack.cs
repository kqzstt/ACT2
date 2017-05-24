using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAttack : MonoBehaviour {
    public static UIAttack _instance;
    
    public GameObject normalA;
    public GameObject rangeA;
    public GameObject redA;



    void Awake()
    {
        _instance = this;
    }
    // Use this for initialization
	void Start () {
        normalA = transform.Find("NormalAttack").gameObject;
        rangeA = transform.Find("RangeAttack").gameObject;
        redA = transform.Find("RedAttack").gameObject;
		
	}
	
	// Update is called once per frame
    public void TurnToOneAttack()
    {
        normalA.SetActive(false);
        rangeA.SetActive(false);
        redA.SetActive(true);
    }
    public void TurnToTwoAttack()
    {
        normalA.SetActive(true);
        rangeA.SetActive(true);
        redA.SetActive(false);
    }
}
