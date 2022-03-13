using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    public float Health = 100f;
    public float MaxHealth = 100f;
    public float PlayerDamage = 5.0f;
    public float playerSpeed = 1f;
    public float AttackSpeed = 0.5f;
    public bool dash, swingreadyaudio;;
    public float dashSpeed;
    public float inputDashSpeed;
    public float MaxDashes;                 // TO DO: IMPLIMENT THIS
    public float dashDuration = 0.05f;
    public float dashCooldown = 1f;
    public bool dashImmunity;
    public float Time_Elapsed = 2.0f;
    public AudioSource dashSwoosh, swingSwoosh;
    
    public int souls;
    public int exp;
    
    public GameObject Sword;
    public Animator SwordAnim;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        SceneManager.LoadScene("pHUD", LoadSceneMode.Additive);
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
                dashSwoosh.Play();
            }
        }

        // Vector3 mousePos = Input.mousePosition;
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
         diff.Normalize();
 
         float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
         transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        Time_Elapsed += Time.deltaTime;
        if(Input.GetKey(KeyCode.Mouse0) && Time_Elapsed >= AttackSpeed)
        {
            if (!swingreadyaudio)
            {
                StartCoroutine(AttackNow());
                swingSwoosh.Play();
            }
          //  swingreadyaudio = true;
   //         swingSwoosh.Play();
        }
        
    }

    IEnumerator AttackNow()
    {
        // swingSwoosh.Play();
        SwordAnim.SetBool("Attack", true);
        Sword.gameObject.SetActive(true);
        swingreadyaudio = true;
        yield return new WaitForSeconds(0.417f);
        // swingreadyaudio = true;
        Sword.gameObject.SetActive(false);
        SwordAnim.SetBool("Attack", false);
        Time_Elapsed = 0;
        swingreadyaudio = false;
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
