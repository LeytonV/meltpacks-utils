using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Vector2 look;
    public Vector2 yLimits;
    public float xMultiplier = 1;
    public float sensitivity;
    public bool rotateThis;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float multiplier = 1f;
        sensitivity += Input.GetAxisRaw("Mouse ScrollWheel");
        look.x += Input.GetAxis("Mouse X") * sensitivity * xMultiplier * multiplier;
        look.y -= Input.GetAxis("Mouse Y") * sensitivity * multiplier;
        look.y = Mathf.Clamp(look.y, yLimits.x, yLimits.y);
        if (!rotateThis && transform.parent)
        {
            transform.parent.Rotate(Vector3.up * Input.GetAxis("Mouse X") * sensitivity * xMultiplier * multiplier, Space.Self);
            transform.localRotation = Quaternion.Euler(Vector3.right * look.y);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(new Vector3(look.y, look.x, 0));
        }
    }

    public float boolToFloat(bool b)
    {
        if (b)
            return 1;
        else
            return 0;
    }
}
