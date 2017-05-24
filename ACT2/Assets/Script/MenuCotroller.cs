using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCotroller : MonoBehaviour {

    public static MenuCotroller _instance;


    public Color purple;
    public SkinnedMeshRenderer headRenderer;
    public Mesh[] headMeshArray;
    private int headMeshIndex = 0;
    public SkinnedMeshRenderer handRenderer;
    public Mesh[] handMeshArray;
    private int handMeshIndex = 0;
    public SkinnedMeshRenderer[] bodyArray;
    [HideInInspector]
    public Color[] colorArray;
    private int colorIndex =-1;

    void Awake()
    {
        _instance = this;
    }
    
    void Star() {
        colorArray = new Color[]{ Color.blue, Color.cyan, Color.green, purple, Color.red };
        DontDestroyOnLoad(this.gameObject);
    }

    public void OnHeadMeshNext(){
        headMeshIndex++;
        headMeshIndex %= headMeshArray.Length;
        headRenderer.sharedMesh = headMeshArray[headMeshIndex];
    }
    public void OnHandMeshNext(){
        handMeshIndex++;
        handMeshIndex %= handMeshArray.Length;
        handRenderer.sharedMesh = handMeshArray[handMeshIndex];
    
    }
	public void OnChangeColorBlue(){
        colorIndex = 0;
        OnChangeColor(Color.blue);
    }
    public void OnChangeColorCyan() {
        colorIndex = 1;
        OnChangeColor(Color.cyan);
    }
    public void OnChangeColorGreen() {
        colorIndex = 2;
        OnChangeColor(Color.green);
    }
    public void OnChangeColorPurple()
    {
        colorIndex = 3;
        OnChangeColor(purple);
    }
    public void OnChangeColorRed() {
        colorIndex = 4;
        OnChangeColor(Color.red);
    }
    void OnChangeColor(Color c){
        foreach (SkinnedMeshRenderer renderer in bodyArray) {
            renderer.material.color = c;
        }
        
     }
    void Save()
    {
        PlayerPrefs.SetInt("headMeshIndex", handMeshIndex);
        PlayerPrefs.SetInt("handMeshIndex", handMeshIndex);
        PlayerPrefs.SetInt("ColorIndex", colorIndex);
    }
    public void OnPlay() {
        Save();
        Application.LoadLevel(1);
       
    }
}
