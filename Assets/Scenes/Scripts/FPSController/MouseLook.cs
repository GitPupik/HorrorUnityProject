using UnityEngine;
public class MouseLook : MonoBehaviour
{
    float RotationX; 
    float RotationY;
   // float Sensivety = 5f;

    public GameObject PlayerObject;

    public Camera PlayerLook;

    private void Update()
    {
        MouseMove();
    }

    private void MouseMove()
    {
        RotationX += Input.GetAxis("Mouse X");
        RotationY += Input.GetAxis("Mouse Y");

        PlayerLook.transform.rotation = Quaternion.Euler(-RotationY, RotationX, 0f); 
        PlayerObject.transform.rotation = Quaternion.Euler(0f, RotationX, 0f);  
    }
         

}
