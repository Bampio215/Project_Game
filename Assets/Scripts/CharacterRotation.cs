using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    public float rotationSpeed = 1000f; // Tốc độ xoay

    void Update()
    {
        if (Input.GetMouseButton(0)) // Nhấn chuột trái
        {
            float mouseX = Input.GetAxis("Mouse X"); // Lấy chuyển động chuột
            transform.Rotate(Vector3.up, -mouseX * rotationSpeed * Time.deltaTime); // Xoay quanh trục Y
        }
    }
}
