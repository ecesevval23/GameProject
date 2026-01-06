using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 50f;
    public Vector3 axis = Vector3.up;

    void Update()
    {
        transform.Rotate(axis * speed * Time.deltaTime);
    }
}