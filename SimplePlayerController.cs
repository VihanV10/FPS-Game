using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Basic movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;
        transform.Translate(movement);

        // Rotate with the camera
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX);
    }
}

