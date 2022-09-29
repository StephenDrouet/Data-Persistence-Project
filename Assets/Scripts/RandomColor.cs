using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public List<Material> materialColors;
    private MeshRenderer meshRenderer;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        index = Random.Range(0, materialColors.Count);
        meshRenderer.material = materialColors[index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
