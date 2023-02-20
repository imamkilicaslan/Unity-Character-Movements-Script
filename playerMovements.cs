using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    float speed=5f;
    public float sensitivity = 75f;
    float xRotation = 0f;
    public GameObject eyes;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        // değişken tanımlamaları
        float tDD = Time.deltaTime;
        
       /*
        // input axis veri girişinin alınması
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
       */

        // karakter hareket hızının düzeltilmesi
        float playerMoveHorizontal = Input.GetAxis("Horizontal") * tDD * speed;
        float playerMoveVertical = Input.GetAxis("Vertical") * tDD * speed;

        //karakterin konum olarak hareket ettirilmesi
        transform.Translate(new Vector3(playerMoveHorizontal,0,playerMoveVertical));

        // karakter yön hızının düzeltilmesi
        float mouseX= Input.GetAxis("Mouse X") * sensitivity * tDD;
        float mouseY= -Input.GetAxis("Mouse Y") * sensitivity * tDD;

        xRotation += mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //karakterin yön olarak hareket ettirilmesi
        transform.Rotate(new Vector3(0, mouseX, 0));
        eyes.transform.localRotation= Quaternion.Euler(new Vector3(xRotation,0, 0));
        
    }
}
