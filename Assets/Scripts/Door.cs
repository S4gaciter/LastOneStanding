using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public List<Transform> enemySpawns;

    private void Start()
    {
        
    }

    void DeactivateBlockedSpawners()
    {
        for (int i = 0; i < enemySpawns.Count; i++)
        {
            enemySpawns[i].gameObject.SetActive(false);
        }
    }

    public void ActivateBlockedSpawners()
    {
        for(int i = 0; i < enemySpawns.Count; i++)
        {
            enemySpawns[i].gameObject.SetActive(true);
        }
    }
}
