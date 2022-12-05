using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    private float leftBound = -18;
    private PlayerControler playerControllerScript;

    // Start is called before the first frame update
    void Start(){
    	playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControler>();
    }

    // Update is called once per frame
    void Update(){
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x < leftBound){
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Collision");
        if(other.CompareTag("Player")){
        	AudioManager.Instance.PlayPoints();
            playerControllerScript.pointsPlayer += 5;
            Destroy(this.gameObject);
        }
    }
}
