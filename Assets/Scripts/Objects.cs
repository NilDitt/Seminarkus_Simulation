using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{

    public float temperature;
    public float maxTemperature = 100f;

    public float surroundingTemperature = 20f;

    public float surfaceArea;
    public float heatingFactor = 10f;

    public float coolingFactor = 1f;

    public float rayAmmount = 3000;

    public Gradient VisualTemperature;

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = VisualTemperature.Evaluate(0f);

        var GameController = GameObject.FindWithTag("GameController");
        temperature = GameController.GetComponent<gameController>().StartingTemperature;
        surroundingTemperature = GameController.GetComponent<gameController>().StartingTemperature;

        rayAmmount = GameObject.Find("Raycastemmitter").GetComponent<Raycast>().RayAmount;
        print("RayAmmount: " + rayAmmount);

    }
    private void Awake()
    {

        StartCoroutine(SetGradient());

    }

    private void Update()
    {
        coloring();
        adaptTemperature();
    }
    private void coloring()
    {
        gameObject.GetComponent<Renderer>().material.color = VisualTemperature.Evaluate(temperature / maxTemperature);
    }
    private void adaptTemperature()
    {
        float TempDif = temperature-surroundingTemperature;
        temperature -= TempDif * coolingFactor * Time.deltaTime;
    }
    public void HeatingUp()
    {
        if (temperature < maxTemperature)
        {
            temperature += DayCycle.DaytimeMultiplier * heatingFactor / surfaceArea / (rayAmmount / 3);
        }

    }
    IEnumerator SetGradient()
    {
        yield return new WaitForSecondsRealtime(.2f);
        VisualTemperature = gameController.VisualTemperatureMainCopy;
    }
}
