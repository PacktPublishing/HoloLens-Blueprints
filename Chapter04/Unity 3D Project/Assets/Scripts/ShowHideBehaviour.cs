using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Show Hide Behaviour for Speaker Details Pannel
/// </summary>
public class ShowHideBehaviour : MonoBehaviour
{
    public GameObject showHideObject;
    public bool showhide = false;
    private void Start()
    {
        try
        {

            MeshRenderer render = showHideObject.GetComponentInChildren<MeshRenderer>();
            if (render != null)
            {
                render.enabled = showhide;
            }
        }
        catch (System.Exception)
        {
        }

    }
}

