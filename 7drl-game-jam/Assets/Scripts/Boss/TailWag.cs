using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailWag : MonoBehaviour
{
    public float TailWagZNeg = -60f;
    public float TailWagZPos = 60f;
    public bool MovingLeft = true;
    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.rotation.z >= 55 || this.gameObject.transform.rotation.z <= -55)
        {
            MovingLeft = !MovingLeft;
        }

        if(MovingLeft)
        {
            transform.rotation = Quaternion.Slerp(
                this.gameObject.transform.rotation,
                Quaternion.Euler(this.gameObject.transform.rotation.x, this.gameObject.transform.rotation.y, TailWagZNeg),
                Time.deltaTime
            );
        }
        else
        {
            transform.rotation = Quaternion.Slerp(
                this.gameObject.transform.rotation,
                Quaternion.Euler(this.gameObject.transform.rotation.x, this.gameObject.transform.rotation.y, TailWagZPos),
                Time.deltaTime
            );
        }
    }
}
