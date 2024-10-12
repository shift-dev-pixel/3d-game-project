using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_controls : MonoBehaviour
{
    public float mouceSensitivity = 500f;

    public Transform Orientation;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        //блокировка курсора
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //управление мышью
        float mouseX = Input.GetAxis("Mouse X") * mouceSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouceSensitivity * Time.deltaTime;

        //поворот мыши по оси X (ввех и вниз)
        xRotation -= mouseY;

        //зафиксировать вращение
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //поворот мыши по оси Y (вокруг)
        yRotation += mouseX;

        //применение поворота на игрока
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        Orientation.transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
