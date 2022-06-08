using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monster;
    public Vector2 minSpawnPoint;
    public Vector2 maxSpawnPoint;

    public void Spawn(int numOfMonster, float monsterSpeed, int monsterHp)
    {
        int spawnMonster = Random.Range(0, monster.Length);

        for (int i = 0; i < numOfMonster; i++)
        {
            Vector2 spawnPoint = new Vector2();
            spawnPoint.x = Random.Range(minSpawnPoint.x, maxSpawnPoint.x);
            spawnPoint.y = Random.Range(minSpawnPoint.y, maxSpawnPoint.y);
            spawnPoint = spawnPoint + (Vector2)transform.position;

            Enemy enemy = Instantiate(monster[spawnMonster], spawnPoint, Quaternion.identity).GetComponent<Enemy>();
            enemy.SetEnemy(monsterSpeed, monsterHp);
        }
    }
}
