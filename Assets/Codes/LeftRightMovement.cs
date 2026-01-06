using UnityEngine;

public class LeftRightMovement : MonoBehaviour
{
    public float speed = 2f;
    public float width = 4f;

    private Vector3 startPos;
    private float randomOffset; // YENİ: Rastgele başlangıç farkı

    void Start()
    {
        startPos = transform.position;
        // Her obje doğduğunda 0 ile 3.14 (PI) arasında rastgele bir sayı tutar
        randomOffset = Random.Range(0f, 3.14f);
    }

    void Update()
    {
        // Time.time'a offset ekledik, artık hepsi bağımsız!
        float newX = startPos.x + Mathf.Sin((Time.time + randomOffset) * speed) * width;

        transform.position = new Vector3(newX, startPos.y, startPos.z);
    }
}