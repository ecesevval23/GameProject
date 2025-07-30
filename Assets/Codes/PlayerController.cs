using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller; // Reference to the CharacterController component
    public float speed = 12f; // Speed of the character movement

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z; // Calculate movement direction based on input
        controller.Move(move * speed * Time.deltaTime); // Move the character based on input and speed
    }
}
