using System;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    [Header("Mouse Control")]
    [SerializeField] private float mouseSensitivity;
    [Range(0f,90f)]
    [SerializeField] private float maxLookAngleY;
    
    [Header("Rotational Objects")]
    [SerializeField] string rotationalObjectTag;
    
    private GameObject[] yRotationalObjects;
    private float _rotationX;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        yRotationalObjects = GameObject.FindGameObjectsWithTag(rotationalObjectTag);
    }
    private void Update()
    {
        Rotate();
    }
    
    private void Rotate()
    {
        var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _rotationX -= mouseY;
        _rotationX = Mathf.Clamp(_rotationX, -maxLookAngleY, maxLookAngleY);

        foreach (var rotationalObject in yRotationalObjects)    
        {
            rotationalObject.transform.localRotation = Quaternion.Euler(_rotationX,0f, 0f);
        }
        transform.Rotate(Vector3.up * mouseX);
    }
    
    
}
