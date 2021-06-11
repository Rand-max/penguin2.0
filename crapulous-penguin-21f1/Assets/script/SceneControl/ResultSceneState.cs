using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSceneState : ISceneState
{
    private Button ReturnBtn;
    public ResultSceneState(SceneController sceneController) : base(sceneController)
    {
        this.SceneName = "Result";
    }

    public override void SceneBegin()
    {
        ReturnBtn = GameObject.Find("ReturnBtn").GetComponent<Button>();
        if(ReturnBtn) ReturnBtn.onClick.AddListener(OnReturnBtnClick);
    }

    public void OnReturnBtnClick()
    {
        sceneController.SetScene(SceneType.Menu);
    }
}
