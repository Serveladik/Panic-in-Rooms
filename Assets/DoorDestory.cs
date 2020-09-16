using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDestory : MonoBehaviour
{
   [SerializeField]private GameObject destroyedObstacles;
     void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player")
        {
            destroyedObstacles = Instantiate(destroyedObstacles,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    
}
