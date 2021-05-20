using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;
using Lean.Pool;
using DG.Tweening;

public class EmoteBehaviour : MonoBehaviour
{

    public LeanToggle emoteToggle
    {
        get
        {
            return GetComponent<LeanToggle>();
        }
    }

    #region ACTIVATE DEACTIVATE
    public void ActivateMessage()
    {
        emoteToggle.TurnOn();
    }

    public void DeactivateMessage()
    {
        emoteToggle.TurnOff();
    }

    #endregion

    public EmoteCacheData emoteData;

    public SpriteRenderer emoteSpriteRenderer;

    public void SetData(EmoteCacheData _emoteData)
    {
        emoteData = _emoteData;

        if (emoteData.type == EmoteType.PNG)
            emoteSpriteRenderer.sprite = emoteData.emoteSprite;

        if (emoteData.type == EmoteType.GIF)
        {
            Sprite sprite = Sprite.Create(emoteData.emoteGif.mFrames[0], new Rect(0, 0, emoteData.emoteGif.mFrames[0].width, emoteData.emoteGif.mFrames[0].height), new Vector2(0.5f, 0.5f));
            emoteSpriteRenderer.sprite = sprite;
        }
    }
    public void StartEmoteCycle()
    {
        StartCoroutine(EmoteRoutine());

    }

    IEnumerator EmoteRoutine()
    {

        //TODO Set EmoteData        

        mCurFrame = 0;

        //Activate Message
        ActivateMessage();
        

        //Move Message UP
        transform.DOMoveY(transform.position.y + 2, 2);

        yield return new WaitForSeconds(2f);

        //Deactivate Message
        DeactivateMessage();

        yield return new WaitForSeconds(1f);
        //Destroy Message
        //Destroy(gameObject);
        LeanPool.Despawn(gameObject);
    }

    private int mCurFrame = 0;
    private float mTime = 0.0f;


    private void Update()
    {
        if (!emoteToggle.On)
            return;

        if (emoteData.type != EmoteType.GIF)
            return;

        if (emoteData.emoteGif.mFrames == null)
            return;

        mTime += Time.deltaTime;
        
        if (mTime < emoteData.emoteGif.mFrameDelay[mCurFrame])        
            return;
        
        mCurFrame = (mCurFrame + 1) % emoteData.emoteGif.mSpriteFrames.Count;
        mTime = 0.0f;

        //GetComponent<Renderer>().material.mainTexture = emoteData.emoteGif.mFrames[mCurFrame];
        emoteSpriteRenderer.sprite = emoteData.emoteGif.mSpriteFrames[mCurFrame];
    }


}
