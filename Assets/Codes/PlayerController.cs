using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;     // CharacterController component'ine referans
    public float speed = 12f;                  // Yürüme hýzý
    public float gravity = -9.81f;             // Yerçekimi kuvveti (negatif olmalý)
    public float jumpHeight = 3f;              // Zýplama yüksekliði

    private Vector3 velocity;                  // Hareket vektörü (özellikle Y için)
    private bool isGrounded;                   // Yere temas kontrolü

    public Transform groundCheck;              // Ayak altý kontrol objesi (boþ GameObject)
    public float groundDistance = 0.4f;        // Küre yarýçapý
    public LayerMask groundMask;               // Sadece zeminle kontrol

    void Update()
    {
        // Yere temas kontrolü
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Yerdeysek düþüþ hýzýný sýfýrla (küçük negatif deðerle yapýþýk kalýr)
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Yön tuþlarýyla yatay hareket
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Space'e basýldýðýnda zýpla (eðer yerdeysen)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Yerçekimi uygula (her frame yavaþça düþüþ eklenir)
        velocity.y += gravity * Time.deltaTime;

        // Yukarý-aþaðý hareketi uygula
        controller.Move(velocity * Time.deltaTime);
    }
}