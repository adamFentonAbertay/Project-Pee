using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCollisions : MonoBehaviour
{

    HealthBar playersHealth;
  //  public StaminaBar stamina;
    public int damageToRecieve = 20;
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    private void Start()
    {
        playersHealth = GameObject.FindFirstObjectByType<HealthBar>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "projectile(Clone)")
        {
            Debug.Log("player: hit the projectile");

             playersHealth.SetHealth(playersHealth.GetHealth() - damageToRecieve);


        }

    }
        //// Update is called once per frame
        //void Update()
        //{

        //}
    }
