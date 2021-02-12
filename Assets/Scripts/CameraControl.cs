using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform trackingTarget;

    public float followSpeed = 5f;


    void Update()
    {
        float xTarget = trackingTarget.position.x;
        float yTarget = trackingTarget.position.y;

        float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
        float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);

        transform.position = new Vector3(xNew, yNew, transform.position.z);
    }

}
