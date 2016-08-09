using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatBar : MonoBehaviour {

    public Image content;
    private float fillAmount = 0.0f;

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        UpdateBar();
    }

    private void UpdateBar()
    {
        if (content.fillAmount < 0.5f && content.fillAmount >= 0.2f)
        {
            content.color = new Color32(247, 166, 35, 255);
        }
        else if (content.fillAmount < 0.2f)
        {
            content.color = new Color32(227, 41, 41, 255);
        }
        else
        {
            content.color = new Color32(6, 201, 31, 255);
        }
        content.fillAmount += fillAmount;
    }

    public void ChangeBar(float _fillAmount)
    {
        fillAmount = _fillAmount;
    }

    public void TempChangeBar(float _fillAmount)
    {
        content.fillAmount += _fillAmount;
    }
}
