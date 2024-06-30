using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeparentInstantly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
        transform.localScale = Vector3.one;
    }
}
