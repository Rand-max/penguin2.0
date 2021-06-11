using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISceneState
{
    private string m_StateName;
    public string SceneName
    {
        get{ return m_StateName; }
        set{ m_StateName = value; }
    }

    protected SceneController sceneController = null;

    public ISceneState(SceneController sceneController)
    {
        this.sceneController = sceneController;
    }

    public virtual void SceneBegin(){}
    public virtual void SceneUpdate(){}
    public virtual void SceneEnd(){}
}
