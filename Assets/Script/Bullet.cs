using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    

    void Start()
    {
        
    }

    
    void Update()
    {

        Destroy(gameObject, 5f);
    }

    public void shootBullet(Vector3 vecBullet)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(vecBullet);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
            Destroy(gameObject);
    }


}
