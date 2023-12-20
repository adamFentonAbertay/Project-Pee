using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class LightFlicker : MonoBehaviour
{
    public float flickerIntensity = 0.1f;
    public float flickersPerSecond = 5f;
    public float speedRandomness = 1f;
    float RegularIntensity;
    //public Light lightSource;
    public HDAdditionalLightData lightSource;
    float time;
    // Start is called before the first frame update
    void Start()
    {

        RegularIntensity = lightSource.intensity;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * (1 - Random.Range(-speedRandomness, speedRandomness) * Mathf.PI);


        //float randomLightAm = Random.Range(lowerFloatLimit, 1);
        //lightSource.intensity = RegularIntensity * randomLightAm;
        lightSource.intensity = RegularIntensity + Mathf.Sin(time * flickersPerSecond) * flickerIntensity;

    }
}
