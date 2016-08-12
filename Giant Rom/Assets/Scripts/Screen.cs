using UnityEngine;
using System.Collections;

public class Screen : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
    }

    public bool ChangeScreen(string texfilePath, string matfilePath)
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
            return true;
        }
        return false;
    }
}
