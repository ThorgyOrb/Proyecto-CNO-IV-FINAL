using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Houses4 : MonoBehaviour
{
    private float backGroundRepeatWidth=29.3f;
    
    void Start()
    {
        //get box collider 2d component and get the size of the box collider


        BoxCollider2D groundCollider = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the background to the left
        transform.Translate(Vector3.left * Time.deltaTime * 1);
        //if the background is off the screen, move it to the right
        if (transform.position.x < -backGroundRepeatWidth)
        {
            transform.position = new Vector3(backGroundRepeatWidth, 0.92f, 0);
        }
        
        
    }
}
