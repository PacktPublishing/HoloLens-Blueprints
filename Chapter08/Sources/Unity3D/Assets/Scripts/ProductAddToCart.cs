using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class ProductAddToCart : MonoBehaviour, IInputClickHandler, IFocusable
{

    public string addToCartProduct;
    private Color startcolor;

    /// <summary>
    /// On Focus Enter - Gazed
    /// </summary>
    public void OnFocusEnter()
    {
        Renderer r = this.gameObject.GetComponent<Renderer>();
        if (r != null)
        {
            startcolor = r.material.color;
            r.material.color = Color.gray;
        }
    }

    /// <summary>
    /// On Focus Exit - Gaze Exit
    /// </summary>
    public void OnFocusExit()
    {
        Renderer r = this.gameObject.GetComponent<Renderer>();
        if (r != null)
        {
            r.material.color = startcolor;
        }
    }

    /// <summary>
    /// Handle the Tap Evebnt on Add To Cart
    /// </summary>
    /// <param name="eventData"></param>
    public void OnInputClicked(InputEventData eventData)
    {
        APIConnector.Instance.PurchaseProduct(addToCartProduct);
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
