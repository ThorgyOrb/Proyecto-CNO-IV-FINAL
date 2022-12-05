using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProyectil : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the projectile forward
        transform.Translate(Vector3.right * Time.deltaTime * 10);

        //destroy the prefab when it is out of the screen
        if (transform.position.z > 10)
        {
            Destroy(this.gameObject);
        }
        //
    }
}
