using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// RequireComponent: Bu scripti bir objeye attığında otomatik olarak
// CharacterController ve Animator'ı da ekler. Hata yapmanı önler.
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")] // Inspector'da düzenli görünmesi için
    public float speed = 5f;
    public float rotationSpeed = 720f;
    public float jumpSpeed = 10f;
    public float gravity = -9.81f; // Physics.gravity yerine kendi kontrolümüzde olması daha iyidir
    public float fallY = -10f;

    private float ySpeed;
    private CharacterController controller;
    private Animator animator;

    // isGrounded'ı public yapmana gerek yok, controller'ın kendi verisini kullanacağız.
    // Ama animatör için bir değişkende tutabiliriz.
    private bool isGrounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleGameReset();
        HandleMovement();
    }

    // Kod okunabilirliği için işlevleri metotlara böldük (Clean Code)
    void HandleGameReset()
    {
        if (transform.position.y < fallY)
        {
            // İleride burayı bir GameManager üzerinden yapman daha şık olur
            CoinCollector.coinValue = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void HandleMovement()
    {
        // 1. Yer Kontrolü (Ground Check)
        isGrounded = controller.isGrounded;

        if (isGrounded && ySpeed < 0)
        {
            ySpeed = -2f; // Tamamen 0 yapmıyoruz ki yere tam yapışsın (Snap)
            animator.SetBool("isJumping", false);
        }

        // 2. Input Alma
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // 3. Hareket Yönü Hesaplama
        Vector3 moveDirection = new Vector3(x, 0, z);
        moveDirection = transform.TransformDirection(moveDirection); // Kamera açısına göre gerekirse diye

        // Eğer Magnitude 1'den büyükse normalize et (Çapraz gidince hızlanmasın)
        if (moveDirection.magnitude > 1f)
        {
            moveDirection.Normalize();
        }

        // 4. Animasyon
        bool isWalking = moveDirection.magnitude > 0.1f;
        animator.SetBool("isWalking", isWalking);

        // 5. Rotasyon (Karakterin gittiği yöne dönmesi)
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);
        }

        // 6. Zıplama
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            ySpeed = jumpSpeed;
            animator.SetBool("isJumping", true);
        }

        // 7. Yerçekimi Uygulama
        ySpeed += gravity * Time.deltaTime;

        // 8. Son Hareketi Birleştirme ve Uygulama
        // moveDirection (X ve Z) ile ySpeed (Y) birleştiriliyor
        Vector3 finalVelocity = moveDirection * speed;
        finalVelocity.y = ySpeed;

        // SimpleMove KULLANMIYORUZ. Sadece Move.
        controller.Move(finalVelocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Hareketli platform mantığı
        if (hit.gameObject.CompareTag("UpDownMovement"))
        {
            // CharacterController ile parent değiştirmek bazen sorun çıkarabilir.
            // Eğer karakter titrerse buraya farklı bir çözüm gerekir ama şimdilik kalsın.
            transform.SetParent(hit.transform);
        }
        else
        {
            // Platformdan inince parent'ı null yapmalısın yoksa platformla beraber gidersin!
            transform.SetParent(null);
        }
    }
}