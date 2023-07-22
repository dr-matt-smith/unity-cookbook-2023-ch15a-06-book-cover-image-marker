using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class PlacementIndicator : MonoBehaviour
{
    public GameObject planeVisual;
    public TextMeshProUGUI textImageData;
    private ARRaycastManager _raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        _raycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        
        
        _raycastManager.Raycast(screenCenter, hits);       

        if(hits.Count >0)
        {
            // get location hit by ray cast
            Pose hitLocation = hits[0].pose;
            
            // make plane visualiser visible at position and rotation where ray cast strikes
            planeVisual.transform.position = hitLocation.position;
            planeVisual.transform.rotation = hitLocation.rotation;
            if(!planeVisual.activeInHierarchy)
                planeVisual.SetActive(true);
            
            textImageData.text = "plane WAS detected - should show highlighter!";
        } else {
            textImageData.text = "(no plane detected)";            
            planeVisual.SetActive(false);
        }
    }
}