using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public static SpawnManager _instance;
    public EnemySpawn[] monsterSpawnArray;
    public EnemySpawn[] bossSpawnArray;
    public List<GameObject> enemyList = new List<GameObject>();
    public AudioClip VictoryClip;
    void Awake()
    {
        _instance = this;
    }

    // Use this for initialization
	void Start () {

		StartCoroutine(Spawn());
	}
	// Update is called once per frame
    IEnumerator Spawn() {
        //第一波敌人
        foreach (EnemySpawn s in monsterSpawnArray) {
           enemyList.Add(s.Spawn());
        }

        while (enemyList.Count > 0) {
            yield return new WaitForSeconds(0.2f);
        }
    
    //第二波敌人
        foreach (EnemySpawn s in monsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }

        yield return new WaitForSeconds(0.5f);
        foreach (EnemySpawn s in monsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }

        while (enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }
        
        //第三波敌人的生成
        foreach (EnemySpawn s in monsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }

        yield return new WaitForSeconds(0.5f);
        foreach (EnemySpawn s in monsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }
        yield return new WaitForSeconds(0.5f);
        foreach (EnemySpawn s in bossSpawnArray) {
            enemyList.Add(s.Spawn());
        }

        while (enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }
        AudioSource.PlayClipAtPoint(VictoryClip, transform.position, 1f);
    }

}
