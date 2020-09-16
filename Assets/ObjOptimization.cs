using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjOptimization : MonoBehaviour
{
    
    private Vector3 vec;
    // Start is called before the first frame update


    void Update()
    {
        this.vec = new Vector3(Mathf.Sin(Time.time/2), Mathf.Sin(Time.time/2), Mathf.Sin(Time.time/2));
        this.transform.localScale = this.vec;
        if(this.vec.magnitude<=0.02f)
        {
            Destroy(this.gameObject);
        }
    }
   
   
  
}
