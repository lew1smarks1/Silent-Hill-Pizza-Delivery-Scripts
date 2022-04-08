using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform leftSpawner;
    [SerializeField]
    private Transform rightSpawner;
    private bool toDestroy = false;
    private bool roadCreated = false;
    
    private void CreateRoad(float road, float side)//5 different roads, left spawner and right spawner
    {
        if(road==1)
        {
            if(side==0)
            {
                Transform Road1 = Instantiate(GameAssets.GetInstance().Road1);
                Road1.SetPositionAndRotation(leftSpawner.position, Quaternion.Inverse(gameObject.transform.rotation)*Road1.rotation);
 
            }
            else if(side==1)
            {
                Transform Road1 = Instantiate(GameAssets.GetInstance().Road1);
                Road1.SetPositionAndRotation(rightSpawner.position, gameObject.transform.rotation * Road1.rotation);
            }
        }

        else if (road == 2)
        {
            if (side == 0)
            {
                Transform Road2 = Instantiate(GameAssets.GetInstance().Road2);
                Road2.SetPositionAndRotation(leftSpawner.position, Quaternion.Inverse(gameObject.transform.rotation) * Road2.rotation);
            }
            else if(side == 1)
            {
                Transform Road2 = Instantiate(GameAssets.GetInstance().Road2);
                Road2.SetPositionAndRotation(rightSpawner.position, gameObject.transform.rotation * Road2.rotation);
            }
        }

        else if (road == 3)
        {
            if (side == 0)
            {
                Transform Road3 = Instantiate(GameAssets.GetInstance().Road3);
                Road3.SetPositionAndRotation(leftSpawner.position, Quaternion.Inverse(gameObject.transform.rotation) * Road3.rotation);
            }
            else if (side == 1)
            {
                Transform Road3 = Instantiate(GameAssets.GetInstance().Road3);
                Road3.SetPositionAndRotation(rightSpawner.position, gameObject.transform.rotation * Road3.rotation);
            }
        }

        else if (road == 4)
        {
            if (side == 0)
            {
                Transform Road4 = Instantiate(GameAssets.GetInstance().Road4);
                Road4.SetPositionAndRotation(leftSpawner.position, Quaternion.Inverse(gameObject.transform.rotation) * Road4.rotation);
            }
            else if (side == 1)
            {
                Transform Road4 = Instantiate(GameAssets.GetInstance().Road4);
                Road4.SetPositionAndRotation(rightSpawner.position, gameObject.transform.rotation * Road4.rotation);
            }
        }

        else if (road == 5)
        {
            if (side == 0)
            {
                Transform Road5 = Instantiate(GameAssets.GetInstance().Road5);
                Road5.SetPositionAndRotation(leftSpawner.position, Quaternion.Inverse(gameObject.transform.rotation) * Road5.rotation);
            }
            else if (side == 1)
            {
                Transform Road5 = Instantiate(GameAssets.GetInstance().Road5);
                Road5.SetPositionAndRotation(rightSpawner.position, gameObject.transform.rotation * Road5.rotation);
            }
        }
    }//createRoad

    IEnumerator DestroyRoad()//destroys road after vehicle has left it for long enough
    {
        yield return new WaitForSeconds(3f);
        if (toDestroy)
        {
            toDestroy = false;
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)//destroys road after vehicle has left it for long enough
    {
        if (collision.gameObject.CompareTag("Vehicle"))
        {
            StartCoroutine(DestroyRoad());
            toDestroy = true;
        }
    }

    private void OnCollisionStay(Collision collision)//stops the 3 second timer to check if the vehicle is still on the road
    {
        if(collision.gameObject.CompareTag("Vehicle"))
        {
            toDestroy = false;
        }
    }

    private void OnCollisionEnter(Collision collision)//creates only 1 road when the vehicle touches the road
    {
        if(collision.gameObject.CompareTag("Vehicle") && !roadCreated)
        {
            CreateRoad(Random.Range(1, 6), RoadCount.GetInstance().GetRoadCount()%2);//random of the 5 roads, first left then right, then left again and so on
            RoadCount.GetInstance().RoadCountUp();//there were problems with getting multiple left roads at the same time, orientations didn't work out
            roadCreated = true;
        }

    }

}
