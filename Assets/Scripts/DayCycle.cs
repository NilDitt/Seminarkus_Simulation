using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public float DaySpeed = 1;
    public float RotationX;
    public static float DaytimeMultiplier;


    void Update()
    {
        //Rotating the angle point
        transform.Rotate(0.01f * DaySpeed, 0, 0);

        //Getting the Rotation points rotation and taking it`s Sinus to calculate the heating multiplier (if the  the heating multiplier is set to 0.05)

        RotationX = transform.localRotation.eulerAngles.x;
        DaytimeMultiplier = Mathf.Sin((RotationX * Mathf.PI) / 180);
        if (DaytimeMultiplier < 0)
        {
            DaytimeMultiplier = 0.05f;
        }

        //print("RotationX: " + RotationX);
        //print("Daytimemultiplier: " + DaytimeMultiplier);
    }
}
