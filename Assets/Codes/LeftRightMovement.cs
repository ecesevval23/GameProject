using UnityEngine;

public class LeftRightMovement : MonoBehaviour
{
    public float speed = 2f;   
    public float width = 4f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        float newX = startPos.x +
        Mathf.Sin(Time.time * speed) * width;
        transform.position = new Vector3
        (newX, startPos.y, startPos.z);
    }
}