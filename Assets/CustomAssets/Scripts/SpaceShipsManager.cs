using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Microsoft.Mixer;
public class SpaceShipsManager : MonoBehaviour
{
    public SpaceShip spaceShipPrefab;

    public List<SpaceShip> spawnedSpacedships;
    public Dictionary<string,object> playerSpaceShips = new Dictionary<string, object>();

    public Transform targetTransform;
    private void OnEnable() {
        
       // MixerInteractive.OnInteractiveButtonEvent += OnButtonPressed;
        GlobalEventSystem.onStartSpaceCamera += ResetSpaceshits;
        GlobalEventSystem.onEnableMixer += StartMixer;
        GlobalEventSystem.onDisableMixer += StopMixer;

    }

    private void OnDisable() {
        
      //  MixerInteractive.OnInteractiveButtonEvent -= OnButtonPressed;
        GlobalEventSystem.onStartSpaceCamera -= ResetSpaceshits;
        GlobalEventSystem.onEnableMixer -= StartMixer;
        GlobalEventSystem.onDisableMixer -= StopMixer;
    }



    private void Start() {
      //  MixerInteractive.GoInteractive();
      //  MixerInteractive.SetCurrentScene("nothing");
    }

    public void StartMixer()
    {
      //  MixerInteractive.SetCurrentScene("default");

    }

    public void StopMixer()
    {
      //  MixerInteractive.SetCurrentScene("nothing");
    }




   // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SpawnSpaceship();
        }
        // if(Input.GetKeyDown(KeyCode.M))
        // {
        //     StopMixer();    
        // }
        // if(Input.GetKeyDown(KeyCode.N))
        // {
        //     StartMixer();
        // }


       // UpdateMixerInputs();
    }



    public void ResetSpaceshits()
    {
        for (int i = 0; i < spawnedSpacedships.Count; i++)
        {
            Destroy(spawnedSpacedships[i]);
        }
        spawnedSpacedships.Clear();
        playerSpaceShips.Clear();
    }

    public void SpawnSpaceship()
    {
        SpaceShip spaceship = Instantiate(spaceShipPrefab);
        //spaceship.transform.position = gameObject.transform.position;
        spawnedSpacedships.Add(spaceship);
    }
    
    public void SpawnSpaceship(string viewerName)
    {
        if(playerSpaceShips.ContainsKey(viewerName))
        {
            Debug.Log("Player Already Has Spaceship");        
        }
        else
        {
            Debug.Log("Spawn Spaceship by: " + viewerName);        
            //SpaceShip spaceship = Instantiate(spaceShipPrefab,transform.position,);
            SpaceShip spaceship = Instantiate(spaceShipPrefab);
            spaceship.transform.position = gameObject.transform.position;
            //spaceship.targetObject = targetTransform;
            playerSpaceShips.Add(viewerName,spaceship);
            spaceship.SetViewerText(viewerName);
            spawnedSpacedships.Add(spaceship);
        }
    }

    //MixerInteractive.OnInteractiveButtonEventHandler onButtonPressed;

    // public void OnButtonPressed(object sender, InteractiveButtonEventArgs e)
    // {
    //     if(e.IsPressed)
    //     {

    //         Debug.Log("Control ID: " + e.ControlID);            
    //         Debug.Log("Button Pressed By " + e.Participant.UserName);
            
    //         SpawnSpaceship(e.Participant.UserName);                

    //     }


    // }

    public void UpdateMixerInputs()
    {

        //if (MixerInteractive.GetButton("buySpaceship"))
       // {
            //Debug.Log("ButtonPressed");

            //InteractiveParticipant participant = MixerInteractive.GetParticipantWhoGaveInputForControl("buySpaceship");

            
            
            //SpawnSpaceship();
            
            //if (participant != null)
            //{
            //    SpawnSpaceship(participant.UserName);                
                //    viewerRecognitionText.text = participant.UserName + " gave you health!";
            //}
      //  }
    }
}
