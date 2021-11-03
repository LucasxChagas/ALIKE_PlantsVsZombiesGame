using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{

    public GameObject prefabBullet;
    public Transform bulletPoint;
    public AudioSource shootSound;
    private float distance;
    private Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        InvokeRepeating("CheckZombie", 0, 2.5f);
    }

    void CheckZombie()
    {
        if (Physics.Raycast(transform.position, transform.forward, 20, LayerMask.GetMask("Zombies")))
        {
            anim.SetBool("isShooting", true);
        }
        else
        {
            anim.SetBool("isShooting", false);
        }
    }

    public void Shooting()
    {
        shootSound.Play();
        Instantiate(prefabBullet, bulletPoint.position, Quaternion.Euler(0, 0, -90));
    }

}
