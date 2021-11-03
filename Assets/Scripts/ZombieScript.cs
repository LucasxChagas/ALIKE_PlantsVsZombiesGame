using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{

    public float life, vel;
    private bool canWalk, canAttack;
    private Rigidbody rb;
    private Animator anim;
    private AudioSource  sound;
    
    [SerializeField] private Renderer rendHead;
    [SerializeField] private Renderer rendBody;

    public bool isAxe, isShield;

    public float velWalkSlow, velWalkFast;
    
    public Color ZombieColor, zombieInitialColor;


    void Start()
    {
        canAttack = true;
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        rendHead.material.color = zombieInitialColor;
        rendBody.material.color = zombieInitialColor;
    }

    void Update()
    {
        CheckDeath();
        CheckCharacter();
    }

    private void FixedUpdate()
    {
        if (canWalk)
        {
            rb.velocity = new Vector3(vel + (vel * Time.deltaTime), 0, 0);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    void CheckDeath()
    {
        if (life <= 0)
        {
            vel = 0;
            GetComponent<Collider>().enabled = false;
            anim.SetTrigger("Death");
            Destroy(gameObject, 2f);
        }
    }

    void CheckCharacter()
    {
        RaycastHit hit; 
        if (Physics.Raycast(transform.position, transform.right, out hit, 1f, LayerMask.GetMask("Character")))
        {
            anim.SetBool("isAttacking", true);
            canWalk = false;
            if(canAttack)
            {
                StartCoroutine(Attack(hit.collider));
            }
        } 
        else
        {
            StopCoroutine("Attack");
            canWalk = true;
            canAttack = true;
            anim.SetBool("isAttacking", false);
        }
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
    
    IEnumerator Attack(Collider col)
    {
        canAttack = false;
        yield return new WaitForSeconds(1.5f);
        canAttack = true;
        if (col != null)
        {
            if (isAxe)
            {
                col.gameObject.GetComponent<CharacterProperties>().life--;
                col.gameObject.GetComponent<CharacterProperties>().life--;
            }
            else
            {
                col.gameObject.GetComponent<CharacterProperties>().life--;
            }
        }
    }

    public void WalkSlow()
    {
        if (!isShield)
        {
            StopCoroutine("WalkFast");
            rendHead.material.color = ZombieColor;
            rendBody.material.color = ZombieColor;
            if (life <= 0)
            {
                CheckDeath();
                anim.SetTrigger("Death");
            }
            else
            {
                vel = velWalkSlow;
            }

            StartCoroutine("WalkFast");
        }
    }

    IEnumerator WalkFast()
    {
        yield return new WaitForSeconds(5);
        rendHead.material.color = zombieInitialColor;
        rendBody.material.color = zombieInitialColor;
        vel = velWalkFast;
    }
}
