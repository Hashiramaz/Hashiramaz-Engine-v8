using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public Color gizmosCOlor = Color.red;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnDrawGizmos() {
        
        
        Gizmos.color = gizmosCOlor;
        Gizmos.DrawCube(transform.position,transform.localScale);

    }

    public Vector3 GetRandomPoint(){
        Vector3 origin = transform.position;
        Vector3 range = transform.localScale / 2.0f;
        Vector3 randomRange = new Vector3(Random.Range(-range.x, range.x),
                                  Random.Range(-range.y, range.y),
                                  Random.Range(-range.z, range.z));
        
        Vector3 randomCoordinate = origin + randomRange;

        return randomCoordinate;
    }
}
