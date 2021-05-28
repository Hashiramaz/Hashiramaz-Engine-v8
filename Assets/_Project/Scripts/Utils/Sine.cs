using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sine : MonoBehaviour {

// progress variables
public string movement;     // options = angle, scale
public float maxValue;
public float speed;
bool UI = false;
float direction;
float progress = -1;

// movement variables
Quaternion startQuat;
Quaternion endQuat;
Vector2 startV2;
Vector2 endV2;

// Call this to start the rotation
void Start(){
    SetStartingValues();
}

void Update() {
    UpdValue();
    Move();    
    }

void SetStartingValues(){
    switch(movement){
        case "angle":
            startQuat = transform.rotation;
            endQuat = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, maxValue);
            break;
        case "scale":
            startV2 = transform.localScale;
            endV2 = Vector2.one * maxValue;
            break;
    }
    progress = 0;

    if(gameObject.GetComponent<RectTransform>() != null)
        UI = true;
}
void UpdValue(){
    if(direction > 0){
        if (progress < 1 && progress >= 0)
            progress += Time.deltaTime * speed * direction;
        else{
            progress = 1;
            direction = -1;
        }
    }
    else{
        if (progress > 0 && progress <= 1)
            progress += Time.deltaTime * speed * direction;
        else{
            progress = 0;
            direction = 1;
        }
    }
}    
void Move(){
    switch (movement){
        case "angle":
            if(UI)
                gameObject.GetComponent<RectTransform>().rotation = Quaternion.Lerp(startQuat, endQuat, progress);
            else
                transform.rotation = Quaternion.Lerp(startQuat, endQuat, progress);
            break;
        case "scale":
            if(UI)
                gameObject.GetComponent<RectTransform>().localScale = Vector2.Lerp(startV2, endV2, progress);
            else
                transform.localScale = Vector2.Lerp(startV2, endV2, progress);
            break;
    }
}

}