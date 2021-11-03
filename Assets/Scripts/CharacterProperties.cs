using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProperties : MonoBehaviour
{
    public int life, price, timeRecharge;
    private AudioClip sound;
    public AudioSource deathSound;
    private Animator anim;


    void Start()
    {
        sound = Resources.Load("Audios/remove", typeof(AudioClip)) as AudioClip;
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        CheckAlive();
        CheckMouse();
    }

    void CheckAlive()
    {
        if (life <= 0)
        {
            GetComponent<Collider>().enabled = false;
            anim.SetTrigger("Death");
            Destroy(gameObject, 2f);
        }
    }

    public void DeathSound()
    {
        deathSound.Play();
    }

    void CheckMouse()
    {
        if (gameObject.tag == "Character")
        {
            OnMouseDown();
        }

    }
    void OnMouseDown()
    {
        if (GameManager.removeEnabled && Input.GetMouseButtonDown(0))
        {
            GameManager.removeEnabled = false;
            AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }



}
