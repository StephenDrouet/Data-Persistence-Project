using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private SpawnManager spawnManager;
    private UIMainGame uiMainGame;
    // Start is called before the first frame update
    void Start()
    {
        uiMainGame = GameObject.Find("Canvas").GetComponent<UIMainGame>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        StartCoroutine(moveDown());
    }

    private void Update()
    {
        if (gameObject.GetComponentsInChildren<Transform>().Length <= 1)
        {            
            Destroy(gameObject);
        }
        
    }

    IEnumerator moveDown()
    {
        while (spawnManager.isGaming)
        {
            yield return new WaitForSeconds(spawnManager.timeSpawn);
            transform.Translate(Vector3.up * (-3));
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            uiMainGame.GameOver();
        }
        
    }
}
