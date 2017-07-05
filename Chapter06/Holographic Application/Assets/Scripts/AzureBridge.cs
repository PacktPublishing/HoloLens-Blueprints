using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity;
using UnityEngine;
using UnityEngine.Networking;

public class AzureBridge : Singleton<AzureBridge>
{
    public Building buildingModel;

    /// <summary>
    /// Start the Execution
    /// </summary>
    void Start()
    {
        StartCoroutine(GetBuilding());
    }

    /// <summary>
    /// Get the Building Data
    /// </summary>
    /// <returns></returns>
    IEnumerator GetBuilding()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get("http://holoblueprintsensorswebapi.azurewebsites.net/api/building");
        yield return webRequest.Send();

        if (webRequest.isError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            string sensorData = System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data);
            buildingModel = JsonUtility.FromJson<Building>(sensorData);
        }
    }
}
