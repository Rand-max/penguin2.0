using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PieControl : MonoBehaviour
{
    // Start is called before the first frame update
    public playercontroler penguin1;
    public playercontroler penguin2;
    public GameObject penguin1pie;
    public GameObject penguin2pie;

    public Text p1_Text;
    public Text p2_Text;

    void Awake()
    {
        
    }

    void Start()
    {
        penguin1pie.GetComponent<Image>().fillAmount=0.5f;
        penguin2pie.GetComponent<Image>().fillAmount=0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        int p1=penguin1.territory;
        int p2=penguin2.territory;
        penguin1pie.GetComponent<Image>().fillAmount=(float)p1/(p1+p2);
        penguin2pie.GetComponent<Image>().fillAmount=(float)p2/(p1+p2);
        
        SetText();
    }

    private void SetText()
    {
        p1_Text.text = "佔有格數：" + penguin1.territory;
        p2_Text.text = "佔有格數：" + penguin2.territory;
    }
}
