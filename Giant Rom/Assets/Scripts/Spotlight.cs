using UnityEngine;
using System.Collections;

public class Spotlight : MonoBehaviour
{
    Light lightObject;
    public Vector3 target;
    public float speed = 0.05f;

    private Vector3 direction;

    // Use this for initialization
    void Start ()
    {
        lightObject = GetComponent<Light>();
        direction = lightObject.transform.position - target;
    }

    // Update is called once per frame
    void Update ()
    {
        if (!ReachedTarget(lightObject.transform.position, target, speed))
        {
            Vector3 nextLocation = lightObject.transform.position - (direction * speed * Time.deltaTime);
            lightObject.transform.position = nextLocation;
        }
    }

    bool ReachedTarget(Vector3 a, Vector3 b, float precision)
    {
        return Vector3.SqrMagnitude(a - b) < precision;
    }

    void SetTarget(Vector3 _target)
    {
        target = _target;
        direction = lightObject.transform.position - target;
    }

    void SetSpeed(float _speed)
    {
        speed = _speed;
    }
}
