using FPS_Game;
using UnityEngine;

public class PlayerLook : MonoBehaviour, IRotation
{
    public Camera camera;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    private float xRotation = 0f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Rotate(float x, float y)
    {
        float mouseX = x;
        float mouseY = y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
