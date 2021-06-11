using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSceneState : ISceneState
{
    private Button ReturnBtn;
    public TutorialSceneState(SceneController sceneController) : base(sceneController)
    {
        this.SceneName = "Tutorial";
    }

    public override void SceneBegin()
    {
        ReturnBtn = GameObject.Find("ReturnBtn").GetComponent<Button>();
        if(ReturnBtn) ReturnBtn.onClick.AddListener(OnReturnBtnClick);
        Debug.Log(ReturnBtn?.name);
    }

    public override void SceneUpdate()
    {
        sceneController.PlayAudio(sceneController.audioObjects.audioList[9]);
    }

    public void OnReturnBtnClick()
    {
        sceneController.SetScene(SceneType.Menu);
    }
}
