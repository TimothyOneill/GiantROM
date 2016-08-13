using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager; //Reference to the Game Manager.
    public Spectator[] spectators;
    public Spotlight spotlight;
    public Screen screen;

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
            SetDemonstration(0);
            screen.ChangeScreen("Wrasslin", "Assets/Textures/roman_reigns.jpg", "Materials/roman_reigns");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetDemonstration(1);
            screen.ChangeScreen("Jeff Gerstmann", "Assets/Textures/jeff_gerst.jpg", "Materials/jeff_gerst");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetDemonstration(2);
            screen.ChangeScreen("Mario Party", "Assets/Textures/mario_party.jpg", "Materials/mario_party");
        }

        //Set new target for spotlight
        if (spotlight.ReachedTarget())
        {
            spotlight.SetTarget(new Vector3(Random.Range(-10, 10),spotlight.transform.position.y,spotlight.transform.position.z));
            spotlight.SetSpeed(Random.Range(0.1f, 0.9f));
        }

        //Check if the player is in the spotlight if not drop approval.
        if (!spotlight.InSpotLight(GameObject.Find("Dan").transform.position))
        {
            foreach (Spectator s in spectators)
            {
                s.CantSee();
            }
        }
    }

    public void SetDemonstration(int _demonstration)
    {
        foreach (Spectator s in spectators)
        {
            s.Feelings(_demonstration);
        }
    }
}
