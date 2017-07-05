using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class FloorInteractionManager : MonoBehaviour, IFocusable, IInputClickHandler
{

    public void OnFocusEnter()
    {
        //Get the reference of Gazed Floor
        var floorNo = this.gameObject.tag;

        // Query the Building Model Collection to find the data for Gazed Floor
        Floor floor = AzureBridge.Instance.buildingModel.Wings.Select(item => item.Floors.Where(y => y.FloorNumber == floorNo).FirstOrDefault()).FirstOrDefault();

        // Return if no floor return by the services
        if (floor == null)
        {
            return;
        }

        // Get the Sensor data values for floor
        bool IsFire = floor.Rooms[0].IsFire;
        bool IsSmoke = floor.Rooms[0].IsSmoke;
        int temp = floor.Rooms[0].Temperature;

        this.SetFireIndicator(IsFire);
        this.SetSmokeIndicator(IsSmoke);
        this.SetTempIndicator(temp);

        Text buildingTitle = GameObject.FindWithTag("BuildingTitle").GetComponent<Text>();

        buildingTitle.text = floor.FloorNumber;
    }

    /// <summary>
    /// Set the Temp Indicator 
    /// </summary>
    /// <param name="Temp"></param>
    private void SetTempIndicator(int Temp)
    {
        GameObject tempNormalObject = GameObject.FindWithTag("TempNormal");
        GameObject tempHighObject = GameObject.FindWithTag("TempHigh");

        MeshRenderer tempNormalRenderer = tempNormalObject.GetComponentInChildren<MeshRenderer>();
        MeshRenderer tempHighRenderer = tempHighObject.GetComponentInChildren<MeshRenderer>();
        Text tempMessage = GameObject.FindWithTag("TempText").GetComponent<Text>();

        if (Temp > 24)
        {
            tempHighRenderer.enabled = true;
            tempNormalRenderer.enabled = false;
            tempMessage.text = Temp.ToString();

        }
        else
        {
            tempHighRenderer.enabled = false;
            tempNormalRenderer.enabled = true;
            tempMessage.text = Temp.ToString();

        }

    }

    /// <summary>
    /// Set the Smoke Indicator
    /// </summary>
    /// <param name="isSmoke"></param>
    private void SetSmokeIndicator(bool isSmoke)
    {
        GameObject smokeOnObject = GameObject.FindWithTag("SmokeOn");
        GameObject smokeoffObject = GameObject.FindWithTag("SmokeOff");

        MeshRenderer smokeonrenderer = smokeOnObject.GetComponentInChildren<MeshRenderer>();
        MeshRenderer smokeoffRenderer = smokeoffObject.GetComponentInChildren<MeshRenderer>();

        Text smokeMessage = GameObject.FindWithTag("SmokeText").GetComponent<Text>();


        if (isSmoke)
        {
            smokeonrenderer.enabled = true;
            smokeoffRenderer.enabled = false;
            smokeMessage.text = "Yes";

        }
        else
        {
            smokeonrenderer.enabled = false;
            smokeoffRenderer.enabled = true;
            smokeMessage.text = "No";

        }
    }

    /// <summary>
    /// Set Game Object Indicator based on Fire Sensors Values 
    /// </summary>
    /// <param name="isFireIndicator"></param>
    private void SetFireIndicator(bool isFireIndicator)
    {
        GameObject fireonObject = GameObject.FindWithTag("FireOn");
        GameObject fireoffObject = GameObject.FindWithTag("FireOff");

        MeshRenderer fireonrenderer = fireonObject.GetComponentInChildren<MeshRenderer>();
        MeshRenderer fireoffRenderer = fireoffObject.GetComponentInChildren<MeshRenderer>();

        Text fireMessage = GameObject.FindWithTag("FireText").GetComponent<Text>();

        if (isFireIndicator)
        {
            fireonrenderer.enabled = true;
            fireoffRenderer.enabled = false;
            fireMessage.text = "Yes";


        }
        else
        {
            fireonrenderer.enabled = false;
            fireoffRenderer.enabled = true;
            fireMessage.text = "No";
        }
    }

    public void OnFocusExit()
    {

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInputClicked(InputEventData eventData)
    {
        GameObject detailsPanel = GameObject.FindWithTag("DetailsPanel");
        CanvasGroup detailsPanelRenderer = detailsPanel.GetComponentInChildren<CanvasGroup>();

        if (detailsPanelRenderer.alpha == 1)
            detailsPanelRenderer.alpha = 0;
        else
            detailsPanelRenderer.alpha = 1;

    }
}
