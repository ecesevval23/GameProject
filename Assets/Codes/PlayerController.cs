using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;
    public float rotationSpeed = 150f; // Dönüş hızı (Bunu Inspector'dan kendine göre ayarla)
    public float jumpSpeed = 10f;
    public float gravity = -9.81f;
    public float fallY = -10f;

    private float ySpeed;
    private CharacterController controller;
    private Animator animator;
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

    void HandleGameReset()
    {
        if (transform.position.y < fallY)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.RestartGame();
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void HandleMovement()
    {
        // 1. Yer Kontrolü
        isGrounded = controller.isGrounded;

        if (isGrounded && ySpeed < 0)
        {
            ySpeed = -2f;
            animator.SetBool("isJumping", false);
            animator.SetBool("isGrounded", true);
        }
        else if (!isGrounded)
        {
            animator.SetBool("isGrounded", false);
        }

        // 2. Input Alma
        // "Horizontal" (Sağ/Sol) tuşları artık sadece DÖNÜŞ için kullanılacak
        float rotInput = Input.GetAxis("Horizontal");

        // "Vertical" (İleri/Geri) tuşları sadece İLERLEMEK için kullanılacak
        float moveInput = Input.GetAxis("Vertical");

        // 3. Dönüş Mantığı (Senin istediğin kısım burası)
        // Karakteri olduğu yerde, basma süresiyle orantılı döndürür
        // Sağa basarsan sağa döner, sola basarsan sola döner.
        transform.Rotate(0, rotInput * rotationSpeed * Time.deltaTime, 0);

        // 4. Hareket Mantığı
        // Karakterin BAKTIĞI YÖNE (transform.forward) doğru gitmesini sağlarız
        Vector3 moveDirection = transform.forward * moveInput;

        // 5. Animasyon
        // Eğer ileri/geri tuşuna basılıyorsa yürüme animasyonu çalışsın
        bool isWalking = Mathf.Abs(moveInput) > 0.1f;
        animator.SetBool("isWalking", isWalking);

        // 6. Hareketi Uygula (Yürüme)
        controller.Move(moveDirection * speed * Time.deltaTime);

        // 7. Zıplama
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            ySpeed = jumpSpeed;
            animator.SetBool("isJumping", true);
        }

        // 8. Yerçekimi Uygula
        ySpeed += gravity * Time.deltaTime;

        // Dikey Hareketi (Zıplama/Düşme) ayrıca uygula
        controller.Move(Vector3.up * ySpeed * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("UpDownMovement"))
        {
            transform.SetParent(hit.transform);
        }
        else
        {
            transform.SetParent(null);
        }

        FallingPlatform platform = hit.gameObject.GetComponent<FallingPlatform>();
        if (platform != null && hit.moveDirection.y < -0.3f)
        {
            platform.StartFalling(); // Platforma "Düş!" emrini ver
        }
    }
    // --- BURAYI EKLE (En alta, son parantezden önce) ---
    public void BouncePlayer(float force)
    {
        // Senin kodunda yukarı/aşağı hızını 'ySpeed' yönetiyor
        ySpeed = force;

        // Zıplama animasyonu devreye girsin ki karakter havada yürür gibi durmasın
        if (animator != null)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isGrounded", false);
        }
    }
    // ----------------------------------------------------
} // Burası senin kodunun en sonundaki parantez