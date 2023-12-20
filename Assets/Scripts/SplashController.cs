using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour
{
    public RawImage splash;
    public AudioSource blowOut;
    float counter = 0;
    bool firstTrig = true;
    Color newcolor = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        counter += Time.deltaTime;
        newcolor.a = 0;
        splash.color = newcolor;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (counter < 1)
        {
            Debug.Log("1");
            newcolor.a += counter;
        }
        if (counter >= 1 && counter < 4.2)
        {
            Debug.Log("2");
            float oldCol = newcolor.a;
            newcolor.a = 1 - Random.Range(0f, 0.2f);
            var randomAgain = Random.Range(0, 10);
            if (randomAgain > 2)
            {
                newcolor.a = oldCol;
            }
        }
         if (counter >= 3.8 && counter < 4.5)
        {
            if (firstTrig == true)
            {
                blowOut.Play();
                firstTrig = false;
            }
        }
        else if (counter >= 4.5 && counter <5)
        {
           
            newcolor.a -= Time.deltaTime * 2;
        }
        else if (counter >=5)
        {
            SceneManager.LoadScene("MainMenu");
        }
       // Debug.Log(newcolor.a);
        splash.color = newcolor;
        counter += Time.deltaTime;
    }
}
