using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float playerSpeed = 1f;
    public bool dash;
    public float dashSpeed;
    public float inputDashSpeed;
    public float dashDuration = 0.05f;
    public float dashCooldown = 1f;
    public bool dashImmunity; 

    // public float boundary_xMin;
    // public float boundary_xMax;
    // public float boundary_yMin;
    // public float boundary_yMax;

    public bool wallCollide;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xDireciton = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical"); 
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical"); 

        Vector3 Movement = new Vector3(xDireciton, yDirection, 0f);
        transform.position += Movement * Time.deltaTime * playerSpeed;

        // transform.position = new Vector3(Mathf.Clamp (transform.position.x, boundary_xMin, boundary_xMax), Mathf.Clamp(transform.position.y, boundary_yMin, boundary_yMax));

        if(Input.GetKey("space")) 
        {
            if(!dash) 
            {
                StartCoroutine(DashNow(xRaw, yRaw));
            }
        }
    }

    IEnumerator DashNow(float x, float y)
    {
        dash = true;

        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2(x, y);

        dashSpeed = inputDashSpeed;
        //rb.velocity = dir.normalized * dashSpeed;
        rb.velocity = dir * dashSpeed;


        dashImmunity = true;

        yield return new WaitForSeconds(dashDuration);

        dashSpeed = 0;
        //rb.velocity = dir.normalized * dashSpeed;
        rb.velocity = dir * dashSpeed;


        // TODO: Impliment in
        dashImmunity = false;

        yield return new WaitForSeconds(dashCooldown);

        dash = false;
    }
}

