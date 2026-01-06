using UnityEngine;

public class LeftRightMovement : MonoBehaviour
{
    public float speed = 2f;
    public float width = 4f;

    private Vector3 startPos;
    private float randomOffset;

    void Start()
    {
        startPos = transform.position;
        randomOffset = Random.Range(0f, 3.14f);
    }

    void Update()
    {
        float newX = startPos.x + Mathf.Sin((Time.time + randomOffset) * speed) * width;

        transform.position = new Vector3(newX, startPos.y, startPos.z);
    }
}