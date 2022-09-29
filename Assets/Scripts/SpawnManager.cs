using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject waveSpawn;
    public float timeSpawn = 16.0f;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(waveSpawn, new Vector3(0, 65, 0), waveSpawn.transform.rotation);
        StartCoroutine(newWave());
    }

    IEnumerator newWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeSpawn);
            Instantiate(waveSpawn, new Vector3(0, 65, 0), waveSpawn.transform.rotation);
        }
    }
}
