using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject destroyedObstacles;
     void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player")
        {
            destroyedObstacles = (GameObject) Instantiate(destroyedObstacles,this.transform.position,Quaternion.identity) ;
            Destroy(this.gameObject);
        }
    }
}
