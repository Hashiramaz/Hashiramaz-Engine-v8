using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Klak.Spout;
using UnityEngine.UI;
public class SpoutReceiverDropdown : MonoBehaviour
{
    public SpoutReceiver spoutReceiver;

    public Dropdown dropdown{
        get{
            return GetComponent<Dropdown>();
        }
    }


    public void SetTarget(string targetName)
    {
        spoutReceiver.sourceName = targetName;
        UpdateDropdown();
    }
    public void SetTarget(int targetIndex)
    {
        List<Dropdown.OptionData> options  = dropdown.options;
        
        spoutReceiver.sourceName = options[targetIndex].text;

                
    }

    private void Start() {
        UpdateDropdown();
    }
    public void UpdateDropdown()
    {
        dropdown.ClearOptions();
        string[] sourceNames = SpoutManager.GetSourceNames();
        
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

        int selectedIndex =0;
        for (int i = 0; i < sourceNames.Length; i++)
        {
            string source = sourceNames[i];
            Dropdown.OptionData optionData = new Dropdown.OptionData(source);
        
            options.Add(optionData);

            if(source == spoutReceiver.sourceName)
                selectedIndex = i;
            
        }
        dropdown.AddOptions(options);     
        


        dropdown.SetValueWithoutNotify(selectedIndex);
    }
}
