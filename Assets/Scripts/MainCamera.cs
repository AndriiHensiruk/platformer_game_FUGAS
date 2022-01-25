using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform trackingObject;
    int distanse = -10;
    float lift = 1.5f;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, lift, distanse) + trackingObject.position;
        transform.LookAt(trackingObject);
    }
}
