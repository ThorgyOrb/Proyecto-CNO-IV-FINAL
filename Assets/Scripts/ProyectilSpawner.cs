using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilSpawner : MonoBehaviour
{
    public GameObject proyectilPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //spawn a projectile prefab when clicking the mouse
        if (Input.GetMouseButtonDown(0))
        {
            //Spawn a projectile at the position of the spawner
            Instantiate(proyectilPrefabs, this.transform.position, Quaternion.identity);
        }
        //make the prefab move forward
        

    
        
        
    }
}
