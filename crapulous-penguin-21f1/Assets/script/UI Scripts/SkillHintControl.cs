using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillHintControl : MonoBehaviour
{
    public playercontroler Playercontroler;
    [SerializeField]private float fadeInTime;
    [SerializeField]private float durationTime;
    [SerializeField]private float fadeOutTime;
    private SkillObject skillObject;
    private float countTimer;
    private CanvasGroup canvasGroup;
    private Text hintText;
    private IEnumerator iEnum; 
    [SerializeField]private bool isFading = false;

    private void OnDisable()
    {
        Playercontroler.skillController.OnSkillChanged -= SetImageAlpha;
        Playercontroler.skillController.OnSkillChanged -= SetHintText;
    }

    public void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        hintText = GetComponentInChildren<Text>();
        canvasGroup.alpha = 0;
    }
    private void Start() 
    {
        Playercontroler.skillController.OnSkillChanged += SetImageAlpha;
        Playercontroler.skillController.OnSkillChanged += SetHintText;
    }

    public void SetImageAlpha(SkillObject skillObject)
    {
        if(skillObject == null) return;

        if(isFading)
        {
            StopCoroutine(iEnum);
            isFading = false;
        }
        iEnum = FadeHint();
        StartCoroutine(iEnum);
        
    }

    public void SetHintText(SkillObject skillObject)
    {
        if(skillObject == null) return;
        hintText.text = $"獲得能力：{skillObject.SkillName}";
    }

    private IEnumerator FadeHint()
    {
        for(float i = 0; i <= fadeInTime; i+=Time.deltaTime)
        {
            if(i == 0) isFading = true;
            canvasGroup.alpha = i / fadeInTime;
            yield return null;
        }

        yield return new WaitForSeconds(durationTime);

        for(float i = fadeOutTime; i >= 0; i-=Time.deltaTime)
        {
            canvasGroup.alpha = i / fadeOutTime;
            if(canvasGroup.alpha <= 0.1f) isFading = false;
            yield return null;
        }
    }

}
