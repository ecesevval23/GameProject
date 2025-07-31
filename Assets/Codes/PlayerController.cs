using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;     // CharacterController component'ine referans
    public float speed = 12f;                  // Y�r�me h�z�
    public float gravity = -9.81f;             // Yer�ekimi kuvveti (negatif olmal�)
    public float jumpHeight = 3f;              // Z�plama y�ksekli�i

    private Vector3 velocity;                  // Hareket vekt�r� (�zellikle Y i�in)
    private bool isGrounded;                   // Yere temas kontrol�

    public Transform groundCheck;              // Ayak alt� kontrol objesi (bo� GameObject)
    public float groundDistance = 0.4f;        // K�re yar��ap�
    public LayerMask groundMask;               // Sadece zeminle kontrol

    void Update()
    {
        // Yere temas kontrol�
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Yerdeysek d���� h�z�n� s�f�rla (k���k negatif de�erle yap���k kal�r)
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Y�n tu�lar�yla yatay hareket
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Space'e bas�ld���nda z�pla (e�er yerdeysen)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Yer�ekimi uygula (her frame yava��a d���� eklenir)
        velocity.y += gravity * Time.deltaTime;

        // Yukar�-a�a�� hareketi uygula
        controller.Move(velocity * Time.deltaTime);
    }
}