using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AnimateTextMeshProColor : MonoBehaviour
{
    public float timeBetweenColors = 1f;
    public Color color1 = Color.red;
    public Color color2 = Color.yellow;
    public bool isAnimating;
    public TextMeshPro textMesh
    {
        get
        {
            return GetComponent<TextMeshPro>();
        }
    }
    private void Start() {
        StartAnimateChangeColor();
    }
    public void StartAnimateChangeColor()
    {
        isAnimating = true;
        StartCoroutine(ChangeColorRoutine());
    }

    IEnumerator ChangeColorRoutine()
    {
        while (isAnimating)
        {
            textMesh.faceColor = color1;
            yield return new WaitForSeconds(timeBetweenColors);
            textMesh.faceColor = color2;
            yield return new WaitForSeconds(timeBetweenColors);
        }
    }

    public void StopAnimatingChangeColors()
    {
        isAnimating = false;
    }
}
