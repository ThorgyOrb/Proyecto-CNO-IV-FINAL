using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public bool isOnGround;
    //get the rigidbody component
    private Rigidbody2D playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //get jump animation
       
        //make te player jump while on the ground

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            isOnGround = false;
        }
        //make the player attack
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<Animator>().SetTrigger("Attack");
            AudioManager.Instance.PlayBalazo();
        }
        //make jump animation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Animator>().SetTrigger("Jump");
            GetComponent<Animator>().SetBool("IsOnGround", false);
        }


       
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GetComponent<Animator>().SetBool("IsOnGround", true);
            isOnGround = true;
        }
    }

}
