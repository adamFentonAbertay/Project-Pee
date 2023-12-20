using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Unity.Netcode;


public class MouseLook : NetworkBehaviour
{

    public float mouseSensitivity = 200;

    public Transform playerBody;
    public GameObject cameraHolder;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        if (IsOwner)
        {
            //cameraHolder.SetActive(true);
            cameraHolder.GetComponentInChildren<Camera>().enabled = true;
        }
        else
        {
            //cameraHolder.SetActive(false);
            cameraHolder.GetComponentInChildren<Camera>().enabled = false;
            // transform.gameObject.SetActive(false);
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
