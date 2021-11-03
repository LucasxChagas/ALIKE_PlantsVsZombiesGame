using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    
    public float vel;
    public AudioClip sound;
    public bool newInstance = false;

    private Rigidbody rb;
    private Collider col;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        Destroy(gameObject, 10);
    }

    
    void Update()
    {
        CheckMouse();
    }

    private void FixedUpdate() 
    {
        if (!newInstance)
        {
            rb.velocity = new Vector3(0, -vel * Time.deltaTime);
        }    
    }
        void CheckMouse()
    {
        if (gameObject.tag == "Money")
        {
            OnMouseDown();
        }

    }
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.cash += 25;
            AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }

}
