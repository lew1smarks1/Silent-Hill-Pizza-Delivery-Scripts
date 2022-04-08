using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCameraScript : MonoBehaviour
{
    public Transform target;
    //script that spins the camera around for the main menu
    private void Update()
    {
        Vector3 relativePos = (target.position + new Vector3(0, 0.5f, 0)) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);//looks at the vehicle

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);//rotates the camera around in a circle slowly
        transform.Translate(1 * Time.deltaTime, 0, 0);
    }
}
