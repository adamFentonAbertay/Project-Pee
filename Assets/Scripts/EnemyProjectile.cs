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
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("projectile: hit the player");

            // playersHealth.SetHealth(playersHealth.GetHealth() - damageToInflict);

            Destroy(gameObject);

        }
        else if (collision.gameObject.tag != "Enemy")
        {
            {
                Debug.Log("projectile: hit other collider");
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);

            }

        }

        // Update is called once per frame
       
    }
}
