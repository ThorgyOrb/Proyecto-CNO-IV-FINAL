using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public bool isOnGround;
    //get the rigidbody component
    private Rigidbody2D playerRB;
    private Animator playerAnim;
    public int pointsPlayer = 0; //score
    public int healthPlayer = 100; //score
    public bool gameOver=false;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //get jump animation
       
        
    	if (Input.GetKeyDown(KeyCode.Space))	//make jump animation
        {
            playerAnim.SetTrigger("Jump");

            playerAnim.SetBool("IsOnGround", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)	//make te player jump while on the ground
        {
        	//AudioManager.Instance.PlayJump();
            playerRB.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            isOnGround = false;
        }
        //make the player attack
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerAnim.SetTrigger("Attack");
            AudioManager.Instance.PlayBalazo();
        }
        
        


       
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerAnim.SetBool("IsOnGround", true);
            isOnGround = true;
        }
    }

}
