using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeDress : MonoBehaviour {

    public SkinnedMeshRenderer headRender;
    public SkinnedMeshRenderer handRender;
    public SkinnedMeshRenderer[] bodyArray;
   // Use this for initialization
	void Start () {
        InitDress();
	}
	
	// Update is called once per frame
	void InitDress() {

        int headMeshIndex = PlayerPrefs.GetInt("headMeshIndex");
        int handMeshIndex = PlayerPrefs.GetInt("handMeshIndex");
        int colorIndex = PlayerPrefs.GetInt("ColorIndex");
       
        headRender.sharedMesh = MenuCotroller._instance.headMeshArray[headMeshIndex];
        handRender.sharedMesh = MenuCotroller._instance.handMeshArray[handMeshIndex];

        /*foreach (SkinnedMeshRenderer render in bodyArray)
        {
            render.material.color = MenuCotroller._instance.colorArray[colorIndex];
        }*/

    }
}
