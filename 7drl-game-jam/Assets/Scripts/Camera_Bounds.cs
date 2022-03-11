using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Bounds : MonoBehaviour
{
    public float SmoothFactor;
    public GameObject Player;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 PlayerOffset = new Vector3(this.Player.transform.position.x, this.Player.transform.position.y, -5);
        Vector3 smoothPosition = Vector3.Lerp(transform.position, PlayerOffset, SmoothFactor*Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}