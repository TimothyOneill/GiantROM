using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager; //Reference to the Game Manager.
    public Spectator[] spectators;
    public Text theme;

    void Awake()
    {
        //Check if instance already exists
        if (gameManager == null)

        //if not, set instance to this
        gameManager = this;

        //If instance already exists and it's not this:
        else if (gameManager != this)

        //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetDemonstration(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetDemonstration(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetDemonstration(3);
        }
    }

    public void SetDemonstration(int _demonstration)
    {
        foreach (Spectator s in spectators)
        {
            s.Feelings(_demonstration);
        }
        theme.text = "Theme " + _demonstration.ToString();
    }


}
