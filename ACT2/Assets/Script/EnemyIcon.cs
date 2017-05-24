using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIcon : MonoBehaviour {

    private Transform icon;
    private Transform player;
    // Use this for initialization
	void Start () {
        if (this.tag == Tags.soulBoss)
        {
            icon = Map._instance.GetBossIcon().transform;
        }
        else if (this.tag == Tags.soulMonster)
        {
            icon = Map._instance.GetMonsterIcon().transform;
        }
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
	}
	
	// Update is called once per frame
    void Update()
    {
        Vector3 offset = transform.position - player.position;
        offset *= 15;
        icon.localPosition = new Vector3(offset.x, offset.z, 0);
    }
    void OnDestroy()
    {
        if (icon != null)
        {
            Destroy(icon.gameObject);
        }
    }
}
