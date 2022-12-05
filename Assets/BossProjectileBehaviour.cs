using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//use light 2d
using UnityEngine.Experimental.Rendering.Universal;

public class BossProjectileBehaviour : MonoBehaviour
{
    public GameObject playerObject;
    public Vector3 playerPos;
    public float speed = 5f;
    public float damage = 10f;
    public float lifeTime = 5f;
    public bool canChase = false;
    // get the animator controller of the projectile
    public Animator anim;
    private bool hasCollided = false;
    //get point light 2d component
    public Light2D pointLight2D;
    // Start is called before the first frame update
    void Start()
    {
        //get child light component
        pointLight2D = GetComponentInChildren<Light2D>();
        //get the animator controller of the projectile
        anim = GetComponent<Animator>();
        //if playerObject is null, then get the player object
        if (playerObject == null)
        {
            //search the gameobject with the tag "Player" and assign it to playerObject
            playerObject = GameObject.FindGameObjectWithTag("Player");
        }
        //if canChase is true, then the projectile will chase the player
        if (!canChase)
        {
            //get the player's position
            playerPos = playerObject.transform.position;
        }
        //start the DestroyProjectile coroutine
        StartCoroutine(DestroyProjectile());
    }

    // Update is called once per frame
    void Update()
    {
        //if canChase is true, then the projectile will chase the player, else it will move towards the player's position
        if (canChase)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
        }
    }

    //make a coroutine that will destroy the projectile after lifeTime seconds
    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(lifeTime);
        //change the animation bool parameter hasCollided to true
        anim.SetBool("destroy", true);
        //change light color to red
        pointLight2D.color = Color.red;
        //destroy the projectile after 0.5 seconds
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if the projectile collides with the player, then the player will take damage
        if (collision.gameObject.tag == "Player" && !hasCollided)
        {
            //change the animation bool parameter hasCollided to true
            anim.SetBool("destroy", true);
            //change light color to red
            pointLight2D.color = Color.red;
            //destroy the projectile after 0.5 seconds
            Destroy(gameObject, 0.7f);
            hasCollided = true;
        }
    }
}
