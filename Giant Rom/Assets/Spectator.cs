using UnityEngine;
using System.Collections;

public class Spectator : MonoBehaviour {

    Animator anim;
    public int likes, hates;
    private int mood; //0 bored, 1 likes, 2 hates;
    public StatBar statBar;
    public SpriteRenderer emotionRenderer;
    public Sprite[] emotions;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void Feelings(int _demonstration)
    {

        if(likes == _demonstration)
        {
            statBar.ChangeBar(0.0005f);
            emotionRenderer.sprite = emotions[0];
        }

        else if(hates == _demonstration)
        {
            statBar.ChangeBar(-0.0005f);
            emotionRenderer.sprite = emotions[1];
        }
        else
        {
            statBar.ChangeBar(0);
            emotionRenderer.sprite = emotions[2];
        }

        if (_demonstration == 4) //Silliness.
        {
            statBar.ChangeBar(0.05f);
            emotionRenderer.sprite = emotions[0];
        }
    }
}
