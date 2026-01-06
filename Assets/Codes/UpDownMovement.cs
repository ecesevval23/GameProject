using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    public float speed = 2f;
    public float height = 2f;

    private Vector3 startPos;
    private float randomOffset; // YENİ

    void Start()
    {
        startPos = transform.position;
        randomOffset = Random.Range(0f, 3.14f);
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin((Time.time + randomOffset) * speed) * height;

        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}