using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        StartCoroutine(moveDown());
    }

    IEnumerator moveDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnManager.timeSpawn);
            transform.Translate(Vector3.up * (-3));
        }

    }
}
