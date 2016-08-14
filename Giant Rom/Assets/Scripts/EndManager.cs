using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndManager : MonoBehaviour
{
    public int score;

    public AudioClip[] audio;
    public AudioSource source;
    public Text reviewText;
    public Image reviewImage;
    public string[] texts;
    public Sprite[] sprites;
    public Image[] stars;


    // Use this for initialization
    void Start()
    {
        SetReview(GameManager.gameManager.activeDuders);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetReview(int s)
    {
        source.PlayOneShot(audio[s - 1]);
        reviewImage.sprite = sprites[s - 1];
        reviewText.text = texts[s - 1];

        foreach (Image i in stars)
        {
            i.enabled = false;
        }

        for (int i = 0; i < s; i++)
        {
            stars[i].enabled = true;
        }
    }

    void ChangeText(string t)
    {
        reviewText.text = t;
    }

}
