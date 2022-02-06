using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public static float surroundingTemperature = 20f;
    public static float NewsurroundingTemperature = 20f;

    //Number of Objects influenced by heating (needed for surrounding temperature calculation)
    public int InfluencedObjects;

    // Sets objects as well as Surroundings Temperature at the Beginning of the Simulation
    public float StartingTemperature = 10f;

    private int waitingcounter = 100;

    //List of objects to which scripts are appended
    public List<GameObject> objList = new List<GameObject>();


    //only for seeingTemperature
    public float showTemperature;

    public Gradient VisualTemperatureMain;
    public static Gradient VisualTemperatureMainCopy;

    private void Start()
    {

        VisualTemperatureMainCopy = VisualTemperatureMain;
        //calculates number of influenced objects (alle the objects need to be in one Folder)
        //Object[] InfluencedObjectLists = Resources.LoadAll("ListofModels");
        //InfluencedObjects = InfluencedObjectLists.Length;
        //Resources.UnloadUnusedAssets();
        //print("numberofObjects " + InfluencedObjects);

        //InfluencedObjects = Directory.GetFiles(Application.dataPath + "/resources/" + LevelDirector, SearchOption.AllDirectories);

        objList.AddRange(GameObject.FindGameObjectsWithTag("SimulationObjects"));
        foreach (GameObject obj in objList)
        {
            obj.AddComponent<Objects>();
            obj.AddComponent<SurfaceCalculater>();
        }
    }
    
    void LateUpdate()
    {
        waitingcounter -= 1;
        if (waitingcounter <= 1)
        {
            calculatingNewTemperature();
            showTemperature = NewsurroundingTemperature;
            waitingcounter = 10000;
        }
    }
    public void calculatingNewTemperature()
    {
        NewsurroundingTemperature = (surroundingTemperature / InfluencedObjects) - 0.1f;
    }

}
