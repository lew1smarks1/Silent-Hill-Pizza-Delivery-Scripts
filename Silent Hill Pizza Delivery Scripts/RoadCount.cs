using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCount : MonoBehaviour
{
    private static RoadCount instance;
    private float roadCount = 0;
    //counts the number of roads, could have made this public to the player as a secondary score
    //used to see whether the next road should be left or right
    private void Awake()
    {
        instance = this;
    }
    public static RoadCount GetInstance()
    {
        return instance;
    }
    public float GetRoadCount()
    {
        return roadCount;
    }
    public void RoadCountUp()
    {
        roadCount++;
    }

}
