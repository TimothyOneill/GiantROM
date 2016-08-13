using UnityEngine;
using System.Collections;

public class EndManager : MonoBehaviour {


   public AudioClip[] audio;
   public AudioSource source;


	// Use this for initialization
	void Start ()
    {
        source.PlayOneShot(audio[0]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
