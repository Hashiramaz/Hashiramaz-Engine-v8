using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorCarRefactored : SpectatorCharacter
{
    public MeshRenderer cardDetail;
    public MeshRenderer doors;


    Material detailMaterial;
    Material detailDoorsMaterial;
    private void Awake()
    {
        detailMaterial = new Material(cardDetail.materials[5]);
        detailDoorsMaterial = new Material(doors.materials[3]);
    }
    public override void ActivateCharacter()
    {
        characterToggle.TurnOn();

        if (twitchUser.IsSub)
            crownToggle.TurnOn();

        SetCarRandomColor();
    }


    public void SetCarRandomColor()
    {
        int randomIndex = UnityEngine.Random.Range(0, textureList.Length);

        //playerBodyRenderer.material.mainTexture = GetTexture(randomIndex);

        SetCarMaterialColor(GetColor(randomIndex));
        SetColorOnText(GetColor(randomIndex));

        SetRandomTextHeight();
    }

    public void SetCarMaterialColor(Color color)
    {
        cardDetail.materials[5].SetColor("_Color",color);
        doors.materials[3].SetColor("_Color",color);
    }
}
