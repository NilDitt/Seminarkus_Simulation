using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public bool Ishitted;
    public bool VisualizeRaycasts = false;

    public float raylenght = 1000f;

    private int counter = 1000;
    public int RoundCounter;
    public int RayAmount = 1000;
    public float scattering = 15f;

   
    public Vector3 RaydirectionTest;

    void Update()
    {
        RaycastHit raycasthit;

        counter = RayAmount;


        while (counter > 0)
        {
            counter -= 1;

            //Transform transformTemp = transform;
            //transformTemp.eulerAngles.Set(transformTemp.eulerAngles.x, 999, transformTemp.eulerAngles.z);

            Vector3 Raydirection = Quaternion.AngleAxis(Random.Range(-scattering, scattering), transform.right) * transform.forward;
                    Raydirection = Quaternion.AngleAxis(Random.Range(-scattering, scattering), transform.up) * Raydirection;


            RaydirectionTest = Raydirection;


            //Debug.Log("0:  " + Raydirection);
            //Raydirection.x += Random.Range(-scattering, scattering);
            //Debug.Log("1:  " + Raydirection);
            //Raydirection.transform.y += Random.Range(-scattering, scattering);
            //Raydirection.y = YDirection;

            //Debug.Log("2:  " + Raydirection);


            //Visualize the Raycasts if is activatet
            if (VisualizeRaycasts == true)
            {
                Debug.DrawRay(transform.position, Raydirection * raylenght, Color.yellow);
            }

            Ishitted = Physics.Raycast(transform.position, Raydirection, out raycasthit, raylenght);

            if (Ishitted)
            {
                //Debug.DrawRay(raycasthit.point, raycasthit.normal, Color.blue);
                //Debug.Log(Vector3.Angle(-transform.forward, raycasthit.normal));
                
                Objects target = raycasthit.transform.GetComponent<Objects>();
                if (target != null)
                {
                    target.HeatingUp();
                }
            }
        }
        RoundCounter += 1;

        //Debug.DrawRay(transform.position, transform.forward * raylenght, Color.yellow);

        
        
    }
}
