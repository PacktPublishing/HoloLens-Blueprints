using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;
using System.Collections;
using System.Linq;
using UnityEngine;

/// <summary>
/// Handle Tap Event on Menu Item and Perform all Associated Tasks
/// </summary>
public class TapHandler : MonoBehaviour, IFocusable, IInputClickHandler
{
    ProductList prodList;
    public Product product;
    GameObject launchedObject;
    AssetBundle bundle;
    Renderer rendererObject;
    Color startcolor;

    /// <summary>
    /// On Focus Enter - Gazed
    /// </summary>
    public void OnFocusEnter()
    {
        rendererObject = this.gameObject.GetComponent<Renderer>();
        if (rendererObject != null)
        {
            startcolor = rendererObject.material.color;
            rendererObject.material.color = Color.blue;
        }
    }

    /// <summary>
    /// On Focus Exit - Gaze Exit
    /// </summary>
    public void OnFocusExit()
    {
        if (rendererObject != null)
        {
            rendererObject.material.color = startcolor;
        }
    }

    /// <summary>
    /// Tap on Menu Item 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnInputClicked(InputEventData eventData)
    {
        this.ClearObjects();

        prodList = APIConnector.Instance.products;

        if (prodList != null)
        {
            Product prod = prodList.Products.FirstOrDefault(item => item.Name == this.gameObject.name);
            string url = prod.AssetURL;
            WWW www = new WWW(url);
            StartCoroutine(DownloadAndProcessAssets(www, prod.AssetName));
        }
    }

    /// <summary>
    /// Clear Object from Assets Bundle
    /// </summary>
    private void ClearObjects()
    {

        if (bundle != null)
        {
            bundle.Unload(false);
        }
    }

    /// <summary>
    /// Download the Process Assets
    /// </summary>
    /// <param name="www"></param>
    /// <param name="assetName"></param>
    /// <returns></returns>
    public IEnumerator DownloadAndProcessAssets(WWW www, string assetName)
    {

        yield return www;
        bundle = www.assetBundle;

        if (www.error == null && bundle != null)
        {
            // Initiate the Hologram
            launchedObject = Instantiate((GameObject)bundle.LoadAsset(assetName));
            launchedObject.transform.position = new Vector3(launchedObject.transform.position.x, this.gameObject.transform.position.y - .25f, this.gameObject.transform.position.z - 1.5f);

            // Add Components on the Fly
            BoxCollider boxCollider = launchedObject.AddComponent<BoxCollider>();
            boxCollider.size = new Vector3(0.50f, 0.50f, 0.25f);

            launchedObject.AddComponent<WorldAnchorManager>();
            launchedObject.AddComponent<TapToPlace>();

            // Instantite the ToolBar 
            GameObject toolBar = Instantiate(Resources.Load("ProductTools", typeof(GameObject)) as GameObject, new Vector3(launchedObject.transform.position.x + 0.5f, launchedObject.transform.position.y, launchedObject.transform.position.z), Quaternion.identity);

            // Check for Wall Paint and Set Referh Button for toolbar to active =false in case it is not wall paint
            if (launchedObject.name != "painting_a(Clone)")
            {
                toolBar.transform.FindChild("Refresh").gameObject.SetActive(false);
            }
            else
            {
                // Attach Action Script for Refresh
                GameObject refreshObject = toolBar.transform.FindChild("Refresh").gameObject;
                ChangePicture changePicture = refreshObject.AddComponent<ChangePicture>();
                changePicture.changeImageObject = launchedObject;
            }

            // Attach Action Script for Close
            GameObject removeProduct = toolBar.transform.FindChild("Close").gameObject;
            ProductRemover remover = removeProduct.AddComponent<ProductRemover>();
            remover.toberemovedObject = launchedObject;


            // Attach Action Script for Add To Cart
            GameObject cart = toolBar.transform.FindChild("AddToCart").gameObject;
            ProductAddToCart prr = cart.AddComponent<ProductAddToCart>();
            prr.addToCartProduct = this.launchedObject.name;

        }
        else
        {
            Debug.Log(www.error);
        }
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
