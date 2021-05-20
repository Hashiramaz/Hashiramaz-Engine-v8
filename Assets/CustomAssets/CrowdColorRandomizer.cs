using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdColorRandomizer : MonoBehaviour
{
    public Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        RandomizeColor();
    }

    private void RandomizeColor()
    {
        Renderer renderer = GetComponent<Renderer>();

        int randomIndex = Random.Range(0, materials.Length);

        renderer.material = materials[randomIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
