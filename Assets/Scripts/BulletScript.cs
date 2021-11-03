using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float vel, damageHit;
    public AudioClip sound;

    public bool isPoison;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 5);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(-vel * Time.deltaTime, 0, 0);

    }

    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Zombie"))
        {
            if(isPoison)
            {
                col.gameObject.GetComponent<ZombieScript>().WalkSlow();
            }
            AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
            col.gameObject.GetComponent<ZombieScript>().life -= damageHit;
            Destroy(gameObject);
        }
    }
}
