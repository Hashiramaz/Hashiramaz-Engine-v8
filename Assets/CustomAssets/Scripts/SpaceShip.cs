using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public float rotateVelocity;
    public Transform spaceShipObject;

    public float spaceShipDistance;

    public TextMesh viewerText;

    

    public Vector2 SpawnDistanceRange = new Vector2(3,10);
    public Vector2 SpawnVelocityRange;

    public Vector3  rotationVector;

    public Transform targetObject;


    private void Start() {
        SetRandomDistance();
        SetRandomVelocity();
        SetRandomRotationDirection();
    }

    public void SetRandomDistance()
    {
        spaceShipDistance = Random.Range(SpawnDistanceRange.x,SpawnDistanceRange.y);

        spaceShipObject.position = new Vector3(spaceShipObject.position.x,spaceShipObject.position.y,spaceShipDistance);
    }

    public void SetRandomVelocity()
    {
        rotateVelocity = Random.Range(SpawnVelocityRange.x,SpawnVelocityRange.y);
    }

    public void SetViewerText(string viewerName){
        viewerText.text = viewerName;
    }

    private void FixedUpdate()
    {
        //transform.Rotate(0,1,0,rotateVelocity * Time.fixedDeltaTime);

        RotateAround();

        

        //Vector3 newDirection = Vector3.RotateTowards(transform.forward, new Vector3(300,0,0), singleStep, 0.0f);
        //Vector3 target = targetObject.position;
        Vector3 target = new Vector3(0,1460,1460);
        Vector3 direction = target - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        spaceShipObject.rotation = rotation;

        RotateViewText();


    }

    public void SetRandomRotationDirection()
    {
        int randomX = Random.Range(-1,2);
        int randomY = Random.Range(-1,2);
        int randomZ = Random.Range(-1,2);

        rotationVector = new Vector3(randomX,randomY,randomZ);

        if(randomX == 0 && randomY == 0)
            SetRandomRotationDirection();
    }

    private void RotateAround()
    {
    
        transform.Rotate(rotationVector, rotateVelocity * Time.fixedDeltaTime);
    }


    public void RotateViewText()
    {
        viewerText.transform.LookAt(Camera.main.transform.position);


    }
}
