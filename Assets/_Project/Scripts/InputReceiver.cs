using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityRawInput;
using UnityEngine.Events;
public class InputReceiver : MonoBehaviour
{
    public bool inputsRunInBackGround;
    public UnityEvent OnPressedEventButton;
    private void OnEnable()
    {
        RawKeyInput.Start(true);
        RawKeyInput.OnKeyDown += OnKeyDown;
    }

    private void OnDisable()
    {
        RawKeyInput.OnKeyDown -= OnKeyDown;
        RawKeyInput.Stop();
    }

    public void OnKeyDown(RawKey key)
    {
        Debug.Log("Key Pressed: " + key);

        #region NUMPAD ON
        if(key == (RawKey.Numpad0))
        {

        }
        if(key == (RawKey.Numpad1))
        {

        }
        if(key == (RawKey.Numpad2))
        {

        }
        if(key == (RawKey.Numpad3))
        {

        }
        if(key == (RawKey.Numpad4))
        {

        }
        if(key == (RawKey.Numpad5))
        {

        }
        if(key == (RawKey.Numpad6))
        {

        }
        if(key == (RawKey.Numpad7))
        {

        }
        if(key == (RawKey.Numpad8))
        {

        }
        if(key == (RawKey.Numpad9))
        {

        }        
        if(key == (RawKey.Decimal))
        {

        }
        
        #endregion

        #region NUMPAD OFF

        //NUMPAD 7
        if(key == (RawKey.Home))
        {

        }
        //NUMPAD 8
        if(key == (RawKey.Up))
        {

        }
        //NUMPAD 9
        if(key == (RawKey.Prior))
        {

        }
        //NUMPAD 4
        if(key == (RawKey.Left))
        {

        }
        //NUMPAD 5
        if(key == (RawKey.Clear))
        {

        }
        //NUMPAD 6
        if(key == (RawKey.Right))
        {

        }
        //NUMPAD 1
        if(key == (RawKey.End))
        {

        }
        //NUMPAD 2
        if(key == (RawKey.Down))
        {

        }
        //NUMPAD 3
        if(key == (RawKey.Next))
        {

        }
        //NUMPAD 0
        if(key == (RawKey.Insert))
        {

        }
        //NUMPAD DECIMAL
        if(key == (RawKey.Delete))
        {

        }

        #endregion

        #region OTHER NUMPAD KEYS
        
        if(key == (RawKey.Return))
        {

        }
        if(key == (RawKey.Add))
        {

        }
        if(key == (RawKey.Subtract))
        {
            OnPressedEventButton?.Invoke();
        }
        if(key == (RawKey.Multiply))
        {

        }
        if(key == (RawKey.Divide))
        {

        }
        if(key == (RawKey.Back))
        {

        }

        #endregion

    }

    public void Toogle()
    {
        if (RawKeyInput.IsRunning)
            RawKeyInput.Stop();

        inputsRunInBackGround = !inputsRunInBackGround;
        RawKeyInput.Start(inputsRunInBackGround);

    }
}
