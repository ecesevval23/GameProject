using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;
    public float fallY;
    private float ySpeed;
    private CharacterController controller;
    private Animator animator;
    public bool isGrounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (transform.position.y < fallY)
        {
            CoinCollector.coinValue = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * x + transform.forward * z;
        moveDirection.Normalize();

        bool isWalking = (x != 0 || z != 0);
        animator.SetBool ("isWalking", isWalking);

        float magnitude = moveDirection.magnitude;
        magnitude = Mathf.Clamp01(magnitude);
        controller.SimpleMove(moveDirection * magnitude * speed);

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            ySpeed = jumpSpeed;
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }

        Vector3 vel = moveDirection * magnitude;
        vel.y = ySpeed;

        controller.Move(vel * Time.deltaTime);

        if (controller.isGrounded)
        {
            ySpeed = -0.5f;
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
        else
        {
            ySpeed += Physics.gravity.y * Time.deltaTime;
        }

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate,
                rotationSpeed * Time.deltaTime);
        }
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("UpDownMovement"))
        {
            transform.parent = hit.transform;
        }
    }
}