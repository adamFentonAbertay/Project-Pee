using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Collider projectileCollider;
    public GameObject explosion;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("projectile: hit the player");
            
           // playersHealth.SetHealth(playersHealth.GetHealth() - damageToInflict);

            Destroy(this);

        }
        else
        {
            Debug.Log("projectile: hit other collider");
            Instantiate(explosion, transform);
            Destroy(this);
        }
       
    }

        // Update is called once per frame
        void Update()
    {
       
    }
}
