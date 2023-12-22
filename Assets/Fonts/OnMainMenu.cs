using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OnMainMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    
    string og;
    public Animator cameraAnimator;
    // Start is called before the first frame update
    void Start()
    {
        og = GetComponent<TextMeshProUGUI>().text;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Mouse pointer entered the UI element
        Debug.Log("Mouse entered UI element!");
        string hoverOverMsg = ">" + GetComponent<TextMeshProUGUI>().text;
        GetComponent<TextMeshProUGUI>().text = hoverOverMsg;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Mouse pointer exited the UI element
        Debug.Log("Mouse exited UI element!");
        GetComponent<TextMeshProUGUI>().text = og;
    }

    public void menuCommand(int ID)
    {
       switch (ID)

        {
            case 1:
            SceneManager.LoadScene("SampleScene");
                break;

            case 2:
                cameraAnimator.SetInteger("MenuState", 2);
                break;
            case 3:
                cameraAnimator.SetInteger("MenuState", 1);
                break;
            case 4:
                cameraAnimator.SetInteger("MenuState", 3);
                break;

        }
        
    }

    private void OnMouseEnter()
    {
        Debug.Log("KILL ME");
    }

    private void OnMouseOver()
    {
        Debug.Log("onmouseover");
        string hoverOverMsg = ">" + GetComponent<TextMeshProUGUI>().text;
        GetComponent<TextMeshProUGUI>().text = hoverOverMsg;
    }
    // Update is called once per frame
    void Update()
    {
        


    }
}
