using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 50f; // Dönme hızı
    public Vector3 axis = Vector3.up; // Hangi eksende dönecek? (Y = Yukarı)

    void Update()
    {
        // Kendi etrafında sürekli dön
        transform.Rotate(axis * speed * Time.deltaTime);
    }
}