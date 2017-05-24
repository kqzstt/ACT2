using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
    public static Map _instance;
    public GameObject IconPrefab;
    private Transform playericon;
    // Use this for initialization
	void Awake () {
        _instance = this;
        playericon = transform.Find("PlayerIcon");	
	}
	
	// Update is called once per frame
	public  Transform GetPlayerIcon() {
		return playericon;
	}

    public GameObject GetBossIcon()
    {
        GameObject go = NGUITools.AddChild(this.gameObject, IconPrefab);
        go.GetComponent<UISprite>().spriteName = "BossIcon";
        return go;
    }
    public GameObject GetMonsterIcon()
    {
        GameObject go = NGUITools.AddChild(this.gameObject, IconPrefab);
        go.GetComponent<UISprite>().spriteName = "EnemyIcon";
        return go;
    }
    
}
