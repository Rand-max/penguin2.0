using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum SceneType
{
    Menu,
    Game,
    Result,
    Tutorial,
    Staff,

}

public class SceneController : MonoBehaviour
{
    private static SceneController _instance;

    public Button startGameBtn;
    public Button tutorialBtn;
    public Button staaffBtn;
    public Button exitGameBtn;

    public AudioObjects audioObjects;
    public AudioSource audioSource;
    private bool audioPlay = false;

    private ISceneState currentSceneState = null;
    private AsyncOperation asyncLoad;
    private bool isRunBegin = false;

    private Dictionary<SceneType, ISceneState> sceneDic;

    private void Awake() 
    {
        if(_instance == null)
        {    
            _instance = this; 
            DontDestroyOnLoad(this.gameObject);
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
        
        // GameObject.DontDestroyOnLoad(this.gameObject);
       
        sceneDic = new Dictionary<SceneType, ISceneState>
        {
            {SceneType.Menu, new MenuSceneState(this)},
            {SceneType.Game, new GameSceneState(this)},
            {SceneType.Tutorial, new TutorialSceneState(this)},
            {SceneType.Result, new ResultSceneState(this)},
        };
        currentSceneState = sceneDic[SceneType.Menu]; 
        // SetScene(SceneType.Menu);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(asyncLoad != null && !asyncLoad.isDone)
        {
            Debug.Log("loading...");
            return;
        } 

        if(currentSceneState != null && isRunBegin == false)
        {
            currentSceneState.SceneBegin();
            isRunBegin = true;
        }

        currentSceneState?.SceneUpdate();
    }

    public void SetScene(SceneType sceneType)
    {
        isRunBegin = false;
        Debug.Log(sceneDic[sceneType].SceneName);
        LoadScene(sceneDic[sceneType].SceneName);
        SceneManager.UnloadSceneAsync(currentSceneState.SceneName);
        if(currentSceneState != null) currentSceneState.SceneEnd();
        currentSceneState = sceneDic[sceneType];
    }

    private void LoadScene(string SceneName)
    {
        if(SceneName == null || SceneName.Length == 0) return;
        asyncLoad = SceneManager.LoadSceneAsync(SceneName);
        // SceneManager.LoadScene(SceneName);
    }

    public void PlayAudio(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        if(!audioSource.isPlaying) audioSource.Play();
    }

    public void PlayAudioOnce(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        if(!audioPlay)
        {
            audioPlay = true;
            audioSource.PlayOneShot(audioClip);
        }
        if(audioPlay && !audioSource.isPlaying)
        {
            audioPlay = false;
        }
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }
}
