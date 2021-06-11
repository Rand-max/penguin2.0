using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSceneState : ISceneState
{
    public MenuSceneState(SceneController sceneController) : base(sceneController)
    {
        this.SceneName = "Menu";
    }

    public override void SceneBegin()
    {
        sceneController.startGameBtn = GameObject.Find("StartGameBtn")?.GetComponent<Button>();
        sceneController.tutorialBtn = GameObject.Find("TutorialBtn")?.GetComponent<Button>();
        sceneController.staaffBtn = GameObject.Find("StaffBtn")?.GetComponent<Button>();
        sceneController.exitGameBtn = GameObject.Find("ExitGameBtn")?.GetComponent<Button>();

        sceneController.startGameBtn?.onClick.AddListener( ()=>OnStartGameClicked() );
        sceneController.tutorialBtn?.onClick.AddListener( ()=>OnTutorialClicked() );
        sceneController.staaffBtn?.onClick.AddListener( ()=>OnStaffClicked() );
        sceneController.exitGameBtn?.onClick.AddListener( ()=>OnExitGameClicked() );
    }

    public override void SceneUpdate()
    {
        sceneController.PlayAudio(sceneController.audioObjects.audioList[8]);
    }

    public override void SceneEnd()
    {
        
    }

    public void OnStartGameClicked()
    {
        Debug.Log("go to game");
        sceneController.SetScene(SceneType.Game);
    }

    public void OnTutorialClicked()
    {
        Debug.Log("go to tutorial");
        sceneController.SetScene(SceneType.Tutorial);
    }

    public void OnStaffClicked()
    {
        //go to staff scene
    }

    public void OnExitGameClicked()
    {
        Application.Quit();
    }
}
