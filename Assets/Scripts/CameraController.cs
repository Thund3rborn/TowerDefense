using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 velocity;
    private float velX, velZ;

    [SerializeField] 
    private float cameraSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(0.0f, 0.0f);
        velX = 0.0f; velZ = 0.0f;

        if (mainCamera == null)
        {
            mainCamera = GetComponent<Camera>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector2(velX, velZ);
        mainCamera.transform.position += new Vector3(velocity.y, 0, velocity.x) * Time.deltaTime;


        if (velX != 0 || velZ != 0)
        {
            velX *= 0.87f;   //for smooth movement
            velZ *= 0.87f;
        }


        if (Input.GetKey(KeyCode.W))
        {
            velX = cameraSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            velX = -cameraSpeed;
        }

        if(Input.GetKey(KeyCode.A))
        {
            velZ = -cameraSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            velZ = cameraSpeed;
        }
    }
}
