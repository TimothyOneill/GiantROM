﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Screen : MonoBehaviour
{
    public Text theme;
    public Sprite[] sprites;
    public string[] titles;
    public Image screen;
    public Text title;

    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
    }

    public void ChangeScreen(int demo)
    {
        //title.text = titles[demo];
        screen.sprite = sprites[demo];
    }

    /*public bool ChangeScreen(string themeText, string texfilePath, string matfilePath)
    {
        if (System.IO.File.Exists(texfilePath))
        {
            byte[] textureData = System.IO.File.ReadAllBytes(texfilePath);
            Texture2D newTexture = new Texture2D(1, 1);
            newTexture.LoadImage(textureData);

            Material newMat = Resources.Load(matfilePath) as Material;
            newMat.mainTexture = newTexture;

            MeshRenderer mr = this.gameObject.GetComponent<MeshRenderer>();
            mr.material = newMat;

            theme.text = themeText;
            return true;
        }
        return false;
    }*/
}
