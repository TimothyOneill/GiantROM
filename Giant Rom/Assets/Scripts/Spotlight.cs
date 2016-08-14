using UnityEngine;
using System.Collections;

public class Spotlight : MonoBehaviour
{
    Light lightObject;
    private Vector3 target;
    public float speed = 0.05f;
    public StatBar powerBar;

    // Use this for initialization
    void Start ()
    {
        lightObject = GetComponent<Light>();
        target = lightObject.transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        lightObject.transform.position = Vector3.Lerp(lightObject.transform.position, target, Time.deltaTime * speed);
    }

    public bool ReachedTarget()
    {
        return Vector3.SqrMagnitude(lightObject.transform.position - target) < 0.01f;
    }

    public bool InSpotLight(Vector3 _in)
    {
        return Mathf.Abs(lightObject.transform.position.x - _in.x) < 1.5f;
    }

    public void SetTarget(Vector3 _target)
    {
        target = _target;
    }

    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }
}
