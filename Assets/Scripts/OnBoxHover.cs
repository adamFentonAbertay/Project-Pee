using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnBoxHover : MonoBehaviour
{

    public TextMeshProUGUI relatedText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    private void OnMouseOver()
    {
        Debug.Log("onmouseover");
        string hoverOverMsg = ">" + relatedText.text;
        relatedText.text = hoverOverMsg;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
