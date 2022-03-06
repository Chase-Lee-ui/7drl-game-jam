using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Bounds : MonoBehaviour
{
    public float SmoothFactor;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 smoothPosition = Vector3.Lerp(transform.position, this.gameObject.transform.position, SmoothFactor*Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}