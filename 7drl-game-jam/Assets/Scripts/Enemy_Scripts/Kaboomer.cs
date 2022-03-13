using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaboomer : MonoBehaviour
{
    public float Damage;
    public GameObject KaboomImage;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<Player_Movement>().Health -= Damage;
            StartCoroutine(Kaboomy());
        }
    }

    IEnumerator Kaboomy()
    {
        KaboomImage.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject.transform.parent.gameObject);
    }
}
