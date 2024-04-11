using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float rotationSpeed = 1f;

    public float scrollspeed = 5f;
    public float minY = 10f; 
    public float maxY = 110f; 
    
    // Update is called once per frame
    void Update()
    {

        if (GameManager.gameEnded) 
        {
            this.enabled = false;
            return;
        }

        if (Input.GetMouseButton(2)) 
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

            CinemachineFreeLook freeLookCam = GetComponent<CinemachineFreeLook>();
            if (freeLookCam != null) 
            {
                freeLookCam.m_XAxis.Value += mouseX;
                freeLookCam.m_YAxis.Value += mouseY;
            } 
            else 
            {
                Debug.LogError("CinemachineFreeLook error");
            }
        }
        

        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)  
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey("s") || Input.mousePosition.y <=  panBorderThickness)  
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)  
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey("a") || Input.mousePosition.x <=  panBorderThickness)  
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        
        Vector3 pos = transform.position;

        pos.y -= scroll * scrollspeed * Time.deltaTime * 1000;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
