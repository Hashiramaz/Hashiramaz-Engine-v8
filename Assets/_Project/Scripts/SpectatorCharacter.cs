using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwitchChatConnect.Data;
using Lean.Gui;
using UnityEngine.UI;
using System;
using TMPro;
public class SpectatorCharacter : MonoBehaviour
{

    public TwitchUser twitchUser;
    public LeanToggle characterToggle
    {
        get{
            return GetComponent<LeanToggle>();
        }
    }

    public LeanToggle crownToggle;
    public TextMeshPro textUserPro;
    public Texture[] textureList;
    public Color[] colorList;
    public SkinnedMeshRenderer playerBodyRenderer;
    public Animator characterAnimator;
    public Text characterNameText;


    private void Update() {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChooseDance(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChooseDance(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChooseDance(2);
        }
    }


    public void SetSpectatorData(TwitchUser user)
    {
        twitchUser = user;        
        //characterNameText.text = twitchUser.Username;
        textUserPro.text = twitchUser.DisplayName;
    }
    public void ActivateCharacter()
    {
        characterToggle.TurnOn();
        
        if(twitchUser.IsSub)
            crownToggle.TurnOn();

        SetFallGuyRandomColor();
    }

    public void DeactivateCharacter()
    {
        characterToggle.TurnOff();
    }

    private void SetFallGuyRandomColor()
    {
        int randomIndex = UnityEngine.Random.Range(0,textureList.Length);
        
        playerBodyRenderer.material.mainTexture = GetTexture(randomIndex);

        SetColorOnText(GetColor(randomIndex));

        SetRandomTextHeight();
    }

    public void SetColorOnText(Color colorSelected)
    {
        textUserPro.fontMaterials[0].SetColor(ShaderUtilities.ID_GlowColor,colorSelected);
    }

    public Texture GetTexture(int index)
    {
        Texture textureSelected = textureList[0];
    
        textureSelected = textureList[index];      

        return textureSelected;        
    }
    public Texture GetTextureRandom()
    {
        Texture textureSelected = textureList[0];

        //TODO PICK RANDOM TEXTURE
        
        int textureIndex = UnityEngine.Random.Range(0,textureList.Length);
        
        textureSelected = textureList[textureIndex];      


        return textureSelected;        
    }

    public Color GetColor(int index)
    {
        return colorList[index];
    }
    
    public void SetRandomTextHeight()
    {
        float randomHeight = UnityEngine.Random.Range(0f , 1.6f);

        //textUserPro.rectTransform.rect.position
        textUserPro.gameObject.transform.parent.localPosition = new Vector3(textUserPro.gameObject.transform.parent.localPosition.x,randomHeight,textUserPro.gameObject.transform.parent.localPosition.z);
    }
    public SpectatorMessageText spectatorMessageText;
    public Transform spectatorMessageSpawnPoint;
    public void SpawnMessage(string messageText)
    {
        
        if(twitchUser.IsSub)
            crownToggle.TurnOn();

        SpectatorMessageText spectatorMessageSpawned = Instantiate(spectatorMessageText,spectatorMessageSpawnPoint.position,spectatorMessageSpawnPoint.rotation);

        spectatorMessageSpawned.StartMessageCycle(messageText);
    }

    public void ChooseDance(int danceIndex)
    {
        characterAnimator.SetInteger("passinhoIndex",danceIndex);
    }

}
