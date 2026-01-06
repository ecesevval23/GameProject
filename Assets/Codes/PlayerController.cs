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
    public float rotationSpeed = 150f;
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

        float rotInput = Input.GetAxis("Horizontal");

        float moveInput = Input.GetAxis("Vertical");

        transform.Rotate(0, rotInput * rotationSpeed * Time.deltaTime, 0);

        Vector3 moveDirection = transform.forward * moveInput;

        bool isWalking = Mathf.Abs(moveInput) > 0.1f;
        animator.SetBool("isWalking", isWalking);

        controller.Move(moveDirection * speed * Time.deltaTime);

        // 7. Zıplama
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            ySpeed = jumpSpeed;
            animator.SetBool("isJumping", true);
        }

        ySpeed += gravity * Time.deltaTime;

        // Dikey Hareketi ayrıca uygula
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
            platform.StartFalling();
        }
    }
    public void BouncePlayer(float force)
    {
        ySpeed = force;

        if (animator != null)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isGrounded", false);
        }
    }
}