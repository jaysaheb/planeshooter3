using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] enemy;
    public float respawnTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator EnemySpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
       
    }
    void SpawnEnemy()
    {
       int randomValue=Random.Range(0, enemy.Length);
       int randomXPos=Random.Range(-2, 2);
        Instantiate(enemy[randomValue], new Vector2(randomXPos,transform.position.y), Quaternion.identity);
    }
}
