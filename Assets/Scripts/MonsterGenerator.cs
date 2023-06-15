using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    public List<GameObject> monster;
    public Transform spawnPos;

    public float spawnTime = 0.01f; //같은 몬스터 스폰 시간
    public float levelTime = 10; //몬스터 종류 스폰 시간
    void Start()
    {
        StartCoroutine(Spawn());

    }

    //몬스터 스폰
    IEnumerator Spawn()
    {
        for (int i = 0; i < monster.Count; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject _monster = Instantiate(monster[i]);
                _monster.transform.position = spawnPos.position;
                yield return new WaitForSeconds(spawnTime);
            }
            yield return new WaitForSeconds(levelTime);
        }
        
    }
}
