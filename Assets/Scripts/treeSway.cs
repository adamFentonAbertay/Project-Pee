using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeSway : MonoBehaviour
{

    
    bool inWindZone = false;

  

    Rigidbody rb;
    Vector3 swayAmount; // Adjust the sway amount to control the intensity of the sway
    Vector3 swaySpeed;
    float randomMulti1;
  
    Vector3 ogPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       randomMulti1 = Random.Range(0.8f, 1.2f);

        ogPos = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (inWindZone)
        {

            //rb.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strength);
            //Vector3 swayDirection = Random.onUnitSphere; // Random direction for a more natural sway
            //rb.AddForce(swayDirection * swayForce, ForceMode.Force);


            float swayRotation = Mathf.Sin(Time.time * swaySpeed.x) * swayAmount.x;
            float swayRotation2 = Mathf.Sin(Time.time * swaySpeed.y) * swayAmount.y;
            float swayRotation3 = Mathf.Sin(Time.time * swaySpeed.z) * swayAmount.z;



            // Apply the sway rotation to the GameObject's Y-axis (you can modify this based on your needs)
            transform.rotation = Quaternion.Euler(swayRotation + ogPos.x, swayRotation2 + ogPos.y, swayRotation3 + ogPos.z);

        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "windArea")
        {
          
            inWindZone = true;
            swayAmount = coll.GetComponent<WindController>().swayAmount;
            swaySpeed = coll.GetComponent<WindController>().swaySpeed;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "windArea")
        {
            
            inWindZone = false;
        }
    }
}
