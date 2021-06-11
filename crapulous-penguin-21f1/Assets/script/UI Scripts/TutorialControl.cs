using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TutorialControl : MonoBehaviour
{
    public Image tutorial;
    public List<Button> tutorialDots;
    public Button leftArrow;
    public Button rightArrow;
    public TutorialImage tutorialImages;

    private Dictionary<Button, Sprite> tutorialDic;
    private GameObject activeBtnObject;
    private Button currentBtn;

    // Start is called before the first frame update
    void Awake()
    {
        tutorialDic = new Dictionary<Button, Sprite>();
        for(int i = 0; i < tutorialDots.Count; i++)
        {
            tutorialDic.Add(tutorialDots[i], tutorialImages.Tutorial[i]);
        }

        for(int i = 0; i < tutorialDots.Count; i++)
        {
            tutorialDots[i].onClick.AddListener(SetTutorial);
        }
        leftArrow.onClick.AddListener(SetLeftTutorial);
        rightArrow.onClick.AddListener(SetRightTutorial);
    }

    void Start()
    {
        currentBtn = tutorialDots[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTutorial()
    {
        activeBtnObject = EventSystem.current.currentSelectedGameObject;

        currentBtn = activeBtnObject.GetComponent<Button>();
        if(currentBtn == null || !tutorialDic.ContainsKey(currentBtn)) return;

        SetBtnActive();
        tutorial.sprite = tutorialDic[currentBtn];
    }

    private void SetBtnActive()
    {
        for(int i = 0; i < tutorialDots.Count; i++)
        {
            tutorialDots[i].GetComponent<Image>().color = new Color32(255,255,255,255);
        }
        currentBtn.GetComponent<Image>().color = new Color32(165,245,255,255);
    }

    public void SetLeftTutorial()
    {
        int index = 0;
        for(int i = 0; i < tutorialDots.Count; i++)
        {
            if(currentBtn == tutorialDots[i])
            {
                index = i;
                break;
            } 
        }
        if(index == 0) return;
        currentBtn = tutorialDots[index-1];
        SetBtnActive();
        tutorial.sprite = tutorialDic[currentBtn];
    }

    public void SetRightTutorial()
    {
        int index = 0;
        for(int i = 0; i < tutorialDots.Count; i++)
        {
            if(currentBtn == tutorialDots[i])
            {
                index = i;
                break;
            } 
        }
        if(index == tutorialDots.Count-1) return;
        currentBtn = tutorialDots[index+1];
        SetBtnActive();
        tutorial.sprite = tutorialDic[currentBtn];
    }
}
