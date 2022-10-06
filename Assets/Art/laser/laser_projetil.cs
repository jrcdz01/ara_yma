using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_projetil : MonoBehaviour
{
    public int timeToDestroy = 2;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * -500);
        Destroy(gameObject, timeToDestroy);
    }

   
}
