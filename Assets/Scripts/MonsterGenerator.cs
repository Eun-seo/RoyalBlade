using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    public List<GameObject> monster;
    public Transform spawnPos;

    public float spawnTime = 0.01f;
    public float levelTime = 10;
    void Start()
    {
        StartCoroutine(Spawn());

    }

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
