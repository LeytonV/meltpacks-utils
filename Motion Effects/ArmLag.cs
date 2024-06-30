using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmLag : MonoBehaviour
{
    public float distance;

    public float damping;

    private Vector3 startPos;

    public float verticalLag;
    public float verticalLagSmooth;

    float oldHeight;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float currentHeight = transform.root.position.y;

        Vector3 input = new Vector3(Input.GetAxis("Horizontal") * distance, 0, Input.GetAxis("Vertical") * distance);
        Vector3 pos = Vector3.Lerp(transform.localPosition, startPos - input, Time.deltaTime * damping);
        pos.y = 0;

        float YLag = currentHeight - oldHeight;

        pos.y = Mathf.Lerp(transform.localPosition.y, -1 * YLag * verticalLag, Time.deltaTime * verticalLagSmooth);
        transform.localPosition = pos;

        oldHeight = transform.root.position.y;
    }
}
