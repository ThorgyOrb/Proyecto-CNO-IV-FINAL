using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControler : MonoBehaviour
{
    public bool isOnGround;
    //get the rigidbody component
    private Rigidbody2D playerRB;
    private Animator playerAnim;
    public int pointsPlayer = 0; //score
    public float healthPlayer = 100f; 
    public bool gameOver=false;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        healthPlayer=100f;
    }

    // Update is called once per frame
    void Update()
    {
        //update the lifeText to show the remaining health
        lifeText.text = "Life: " + healthPlayer.ToString("0");
        //update the scoreText to show the remaining points
        scoreText.text = "Score: " + pointsPlayer.ToString("0");
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

        //move the player to the right and left with the keyboard limits by the camera
        if (Input.GetKey(KeyCode.D) && transform.position.x < 10)
        {
            transform.Translate(Vector2.right * 5 * Time.deltaTime);
            playerAnim.SetBool("IsRunning", true);
        }
        else if (Input.GetKey(KeyCode.A) && transform.position.x > -10)
        {
            transform.Translate(Vector2.left * 5 * Time.deltaTime);
            playerAnim.SetBool("IsRunning", true);
        }
        else
        {
            playerAnim.SetBool("IsRunning", false);
        }


         if (healthPlayer <= 0)
            {
                
                playerAnim.SetTrigger("Dead");
                playerAnim.SetBool("Dead", true);
                RestartGame();
            
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            healthPlayer -= 10;
            if (healthPlayer <= 0)
            {
                
                playerAnim.SetTrigger("Dead");
                playerAnim.SetBool("Dead", true);
               RestartGame();                                  
            }
        }
        

        if (collision.gameObject.tag == "Thunder")
        {
            healthPlayer -= 30;
            if (healthPlayer <= 0)
            {
                
                playerAnim.SetTrigger("Dead");
                playerAnim.SetBool("Dead", true);
                RestartGame();
            
            }
        }
      
    }
//restart the game
    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }



}
