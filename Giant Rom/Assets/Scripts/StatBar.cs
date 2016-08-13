using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatBar : MonoBehaviour {

    public Image content;
    public Color32 defaultColour;
    public Color32 fillColour1;
    public Color32 fillColour2;
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
            content.color = fillColour1;
        }
        else if (content.fillAmount < 0.2f)
        {
            content.color = fillColour2;
        }
        else
        {
            content.color = defaultColour;
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

    public float GetFillamount()
    {
        return content.fillAmount;
    }

    public void SetFillAmount(float _fillAmount)
    {
        content.fillAmount = _fillAmount;
    }
}
