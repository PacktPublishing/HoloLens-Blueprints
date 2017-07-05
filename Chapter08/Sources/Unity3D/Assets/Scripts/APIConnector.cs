using HoloToolkit.Unity;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// API Connector - Connecting with Azure
/// </summary>
public class APIConnector : Singleton<APIConnector>
{
    /// <summary>
    /// Asset API URL
    /// </summary>
    string AssetAPIURL = "http://holoretailwepapi.azurewebsites.net/api/assets";

    /// <summary>
    /// List of Products
    /// </summary>
    public ProductList products;

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        StartCoroutine(GetProductDetails());
    }

    /// <summary>
    /// Get Plan Details for Asset API
    /// </summary>
    /// <returns></returns>
    private IEnumerator GetProductDetails()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(AssetAPIURL);
        yield return webRequest.Send();

        if (webRequest.isError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            string productData = System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data);
            products = JsonUtility.FromJson<ProductList>(productData);
        }
    }

    /// <summary>
    /// Add To Cart Service Call
    /// </summary>
    /// <param name="productName"></param>
    public void PurchaseProduct(string productName)
    {
        UnityWebRequest webRequest = UnityWebRequest.Post("http://holoretailwepapi.azurewebsites.net/API/Purchase/AddToCart", productName);
    }
}
