using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;

public class StageActivador : MonoBehaviour
{
        public LeanToggle stageToggle
    {
        get{
            return GetComponent<LeanToggle>();
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.P))
        {
            ToggleStageState();
        }
    }
   public void ToggleStageState()
   {
       stageToggle.Toggle();
   }
}
