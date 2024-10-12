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
        //���������� �������
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //���������� �����
        float mouseX = Input.GetAxis("Mouse X") * mouceSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouceSensitivity * Time.deltaTime;

        //������� ���� �� ��� X (���� � ����)
        xRotation -= mouseY;

        //������������� ��������
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //������� ���� �� ��� Y (������)
        yRotation += mouseX;

        //���������� �������� �� ������
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        Orientation.transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
