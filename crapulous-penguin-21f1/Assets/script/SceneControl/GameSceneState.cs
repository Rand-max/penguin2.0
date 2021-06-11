using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneState : ISceneState
{
    private Animator countDownAni;
    private TimeControl timeControl;
    public GameSceneState(SceneController sceneController) : base(sceneController)
    {
        this.SceneName = "Game";
    }

    public override void SceneBegin()
    {
        countDownAni = GameObject.Find("CountDownImage")?.GetComponent<Animator>();
        timeControl = GameObject.Find("TimeText")?.GetComponent<TimeControl>();

        if(countDownAni != null)
        {
            Time.timeScale = 0;
            countDownAni.Play("AStartCountdown");
            sceneController.PlayAudioOnce(sceneController.audioObjects.audioList[1]);
        } 
    }

    public override void SceneUpdate()
    {
        if(countDownAni != null)
        {
            if(countDownAni.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !countDownAni.IsInTransition(0))
            {
                countDownAni.enabled = false;                
                Time.timeScale = 1;
            }
        }

        if(!sceneController.audioSource.isPlaying) sceneController.PlayAudio(sceneController.audioObjects.audioList[6]);
        
        if(timeControl.countDownTime <= 0f)
        {
            sceneController.SetScene(SceneType.Result);
        }
    }
}
