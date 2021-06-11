using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillImageControl : MonoBehaviour
{
    public playercontroler Playercontroler;
    private Image skillImage;
    private Text remainAmountText;
    private CanvasGroup canvasGroup;

    [SerializeField]private SkillObject skillObject;

    private void Awake() 
    {
        skillImage = GetComponent<Image>();
        remainAmountText = GetComponentInChildren<Text>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Start()
    {
        Playercontroler.skillController.OnSkillChanged += ShowSkillImage;
        Playercontroler.skillController.OnSkillDeleted += HideSkillImage;
        Playercontroler.skillController.OnSkillUsed += UpdateSkill;
        canvasGroup.alpha = 0;
    }

    void OnDisable()
    {
        Playercontroler.skillController.OnSkillChanged -= ShowSkillImage;
        Playercontroler.skillController.OnSkillDeleted -= HideSkillImage;
        Playercontroler.skillController.OnSkillUsed -= UpdateSkill;
    }

    public void ShowSkillImage(SkillObject skillObject)
    {
        if(skillObject == null) return;

        this.skillObject = skillObject;
        skillImage.sprite = skillObject.sprite;

        canvasGroup.alpha = 1;
        remainAmountText.text = Playercontroler.skillController.remainCount.ToString();
    }

    public void UpdateSkill(SkillObject skillObject)
    {
        if(skillObject == null) return;
        
        remainAmountText.text = Playercontroler.skillController.remainCount.ToString();
    }

    public void HideSkillImage()
    {
        skillImage.sprite = null;
        remainAmountText.text = "";
        canvasGroup.alpha = 0;
    }
}
