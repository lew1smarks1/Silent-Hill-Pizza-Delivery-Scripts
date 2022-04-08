using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject thirdCam;
    [SerializeField]
    private GameObject firstCam;
    private int camMode;
    private static CameraScript instance;

    public static CameraScript GetInstance()
    {
        return instance;
    }
    private void Awake()
    {
        instance = this;
    }
    public void SetCamMode()
    {
        camMode = 0;
        StartCoroutine(CamChange());
    }
    public int GetCamMode()
    {
        return camMode;
    }

    void Update()
    {
        if (Input.GetButtonDown("CameraChange") && !VehicleMove.GetInstance().GetDeath())//if player has not lost then you can change the cam to 1st or 3rd
        {
            if(camMode == 1)
            {
                camMode = 0;
            }
            else
            {
                camMode = 1;
            }

            StartCoroutine(CamChange());
        }
    }
    IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01f);//allows for a little time before camera switch
        if (camMode == 0)
        {
            thirdCam.SetActive(true);
            firstCam.SetActive(false);
        }
        if (camMode == 1)
        {
            thirdCam.SetActive(false);
            firstCam.SetActive(true);
        }
    }
}
