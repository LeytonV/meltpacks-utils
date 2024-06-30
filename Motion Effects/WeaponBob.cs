using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBob : MonoBehaviour
{
    public Vector3 originalPosition;
    public float intensity;
    public float xIntensity;
    public float speed;
    public float angle;
    public float offset;


    float multiplier;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 bob = new Vector3(Mathf.Sin((Time.time * speed) + offset) * xIntensity, Mathf.Sin(((Time.time * 2) * speed) + offset), 0);
        transform.localPosition = originalPosition + (bob * intensity * Vector3.ClampMagnitude(input, 1).magnitude * multiplier);

        transform.localRotation = Quaternion.Euler(Vector3.forward * Mathf.Sin(Time.time * speed) * angle * Vector3.ClampMagnitude(input, 1).magnitude * multiplier);
    }

    public void SetMult(float val)
    {
        multiplier = val;
    }
}
