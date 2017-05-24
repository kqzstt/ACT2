using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIcon : MonoBehaviour {

    private Transform player;
    // Use this for initialization
	void Start () {
        player = Map._instance.GetPlayerIcon();
	}
	
	// Update is called once per frame
	void Update () {
        float y = transform.eulerAngles.y;
        player.localEulerAngles = new Vector3(0, 0, -y);
	}
}
