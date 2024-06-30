using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [Header("Rotation")]
    public float maxRotAmount;

    public float RotMultiplier;

    public float RotDamping;

    [Header("Position")]
    public float maxPosAmount;
    public float posMultiplier;
    public float posDamping;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Rotation
        Vector3 RotSway = new Vector3(-Mathf.Clamp(Input.GetAxis("Mouse Y"), -maxRotAmount, maxRotAmount), Mathf.Clamp(Input.GetAxis("Mouse X"), -maxRotAmount, maxRotAmount), 0);

        Vector3 rotEuler = transform.localRotation.eulerAngles;
        rotEuler += RotSway * RotMultiplier;
        transform.localRotation = Quaternion.Euler(rotEuler);


        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(Vector3.zero), Time.deltaTime * RotDamping);

        //Position
        Vector3 PosSway = new Vector3(-Mathf.Clamp(Input.GetAxis("Mouse X"), -maxPosAmount, maxPosAmount), -Mathf.Clamp(Input.GetAxis("Mouse Y"), -maxPosAmount, maxPosAmount), 0);

        Vector3 currentPos = transform.localPosition;
        currentPos += PosSway * posMultiplier;
        transform.localPosition = currentPos;


        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(Vector3.zero), Time.deltaTime * RotDamping);
        transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, Time.deltaTime * posDamping);
    }
}
