using UnityEngine;
using System.Collections;

public class Spectator : MonoBehaviour {

    Animator anim;
    //public int likes, hates;
    //private int mood; //0 bored, 1 likes, 2 hates;
    enum Mood { bored, likes, hates, silly };
    public StatBar statBar;
    public SpriteRenderer emotionRenderer;
    public Sprite[] emotions;
    bool fullReset = false;

    // Use this for initialization
    void Start ()
    {
    }

    // Update is called once per frame
    void Update ()
    {
        if (fullReset)
        {
            if (statBar.GetFillamount() < 0.94f)
            {
                statBar.TempChangeBar(0.05f);
            }
            else
            {
                fullReset = false;
            }
        }
    }

    public void Feelings(int _demonstration)
    {

        if((int)Mood.likes == _demonstration)
        {
            statBar.ChangeBar(0.0005f);
            emotionRenderer.sprite = emotions[0];
        }

        else if((int)Mood.hates == _demonstration)
        {
            statBar.ChangeBar(-0.0005f);
            emotionRenderer.sprite = emotions[1];
        }
        else
        {
            statBar.ChangeBar(0);
            emotionRenderer.sprite = emotions[2];
        }

        if ((int)Mood.silly == _demonstration) //Silliness.
        {
            fullReset = true;
            //statBar.ChangeBar(0.05f);
            emotionRenderer.sprite = emotions[0];
        }
    }

    public void CantSee()
    {
        statBar.TempChangeBar(-0.0005f);
    }
}
