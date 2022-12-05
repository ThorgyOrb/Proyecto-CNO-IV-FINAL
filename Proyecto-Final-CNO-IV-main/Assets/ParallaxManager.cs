using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
    }

    //Move this game object to the left at a constant speed of 5 then reset it to the right
    void MoveLeft()
    {
        transform.Translate(Vector3.left * 5 * Time.deltaTime);
        if (transform.position.x < -20)
        {
            transform.position = new Vector3(20, transform.position.y, transform.position.z);
        }
    }

}
