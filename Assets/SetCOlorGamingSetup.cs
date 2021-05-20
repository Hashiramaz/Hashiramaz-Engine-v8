using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lasp;
public class SetCOlorGamingSetup : MonoBehaviour
{
    public HueColorChangeAtTime huecolorproperty;
    public ColorPropertyBinder colorPropertyBinder;
    public ColorPropertyBinder colorPropertyBinder2;

    
    public AudioLevelTracker levelTracker;
    // Start is called before the first frame update
    void Start()
    {
         Debug.Log("Property binder" + levelTracker.propertyBinders.GetValue(0));
        colorPropertyBinder = (ColorPropertyBinder)levelTracker.propertyBinders.GetValue(0);
        colorPropertyBinder2 = (ColorPropertyBinder)levelTracker.propertyBinders.GetValue(2);

    }

    // Update is called once per frame
    void Update()
    {
        
            //SetColorHue(colorPropertyBinder , huecolorproperty.GetCurrentHueColor());

            if(Input.GetKeyDown(KeyCode.T))
            {
                SetRandomColor();
            }
        
        SetColorHue(colorPropertyBinder,huecolorproperty.GetCurrentHueColor());
        SetColorHue(colorPropertyBinder2,huecolorproperty.GetCurrentHueColor());
        
    }

    public void SetColorHue(ColorPropertyBinder colorProperty, Color color)
    {
         colorProperty.Value0 = color;
         colorProperty.Value1 = color;
    }

    
    public void SetRandomColor()
    {
        Color randomColor = Color.HSVToRGB(Random.Range(0f,1f),1,1);
        SetColorHue(colorPropertyBinder,huecolorproperty.GetCurrentHueColor());
        SetColorHue(colorPropertyBinder2,huecolorproperty.GetCurrentHueColor());


    }
}
