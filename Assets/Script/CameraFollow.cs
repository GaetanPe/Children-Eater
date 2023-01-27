using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // the target of camera (the player)
    public float distance; // distance between camera and target
    public float sensitivity; // sensitivity of the camera rotation
    public float clampAngle; // the limit angle of rotation of the camera
    public float cameraSpeed; // the speed of movement of the camera

    private float currentX = 0f;
    private float currentY = 40f;
    // Start is called before the first frame update
    void Start()
    {
        //for locked cursors
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // récupérer les entrées de la souris
        currentX += Input.GetAxis("Mouse X") * sensitivity;
        

        // limiter l'angle de rotation de la caméra
        currentY = Mathf.Clamp(currentY, -clampAngle, clampAngle);

        // faire tourner la caméra autour de la cible
        transform.rotation = Quaternion.Euler(currentY, currentX, 0f);

        // déplacer la caméra vers la cible
        transform.position = target.position - transform.forward * distance;

        // gérer les déplacements de la caméra avec les touches de direction
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.position += new Vector3(horizontal, 0f,vertical) * cameraSpeed * Time.deltaTime;
    }
}
