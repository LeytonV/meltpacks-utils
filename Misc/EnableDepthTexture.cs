using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class EnableDepthTexture : MonoBehaviour
{
    Camera cam;
    // Start is called before the first frame update
    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.depthTextureMode = DepthTextureMode.Depth;
    }
}
