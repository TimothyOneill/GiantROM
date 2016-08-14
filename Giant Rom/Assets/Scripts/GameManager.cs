using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager; //Reference to the Game Manager.
    public Spectator[] spectators;
    public Spotlight spotlight;
    public Screen screen;
    public int activeDuders;
    public StatBar powerBar;
    float cooldown = -0.01f;
    public Text t;
    public Text instructions;

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
        activeDuders = 6;
        StartCoroutine("Timer");
        SetDemonstration(0);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetDemonstration(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetDemonstration(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetDemonstration(2);
        }

        //Set new target for spotlight
        if (spotlight.ReachedTarget())
        {
            spotlight.SetTarget(new Vector3(Random.Range(-10, 10),spotlight.transform.position.y,spotlight.transform.position.z));
            spotlight.SetSpeed(Random.Range(0.1f, 0.9f));
        }

        //Check if the player is in the spotlight if not drop approval.
        if (spotlight.InSpotLight(GameObject.Find("Dan").transform.position))
        {
            powerBar.ChangeBar(0.001f);
        }
        else
        {
            powerBar.ChangeBar(0);
        }

        cooldown -= 0.01f;

        if(cooldown < 0)
        {
            t.text = "";
        }

        if(powerBar.GetFillamount() == 1)
        {
            instructions.text = "PRESS 4";
        }
        else
        {
            instructions.text = "";
        }
    }

    public void SetDemonstration(int _demonstration)
    {
        if(cooldown < 0)
        {
            foreach (Spectator s in spectators)
            {
                s.Feelings(_demonstration);
            }

            screen.ChangeScreen(_demonstration);

            cooldown = 0.5f;
        }
        else
        {
            t.text = "COOLDOWN";
        }
       
        
    }

    IEnumerator Timer()
    {
        Debug.Log("Timer Started");
        yield return new WaitForSeconds(60);
        EndGame();
    }

    public void EndGame()
    {
        if(activeDuders == 6)
        {
            activeDuders = 5;
        }

        else if(activeDuders == 0)
        {
            activeDuders = 1;
        }
        Application.LoadLevel("EndScreen");
    }
}
