using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class MyImageTracker : MonoBehaviour
{
    public Text textImageData;
    public Transform objectPrefab;
    private ARTrackedImageManager m_TrackedImageManager;

    void Awake()
    {
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnChanged;
    }

    void OnDisable() {
        m_TrackedImageManager.trackedImagesChanged -= OnChanged;
    }

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            Transform newObject = Instantiate(objectPrefab);
            newObject.SetParent(newImage.transform);
            newObject.position = Vector3.zero;
            textImageData.text = "TESLA image - added to tracking";
        }
        
        foreach (var updatedImage in eventArgs.updated)
        {
//            updatedImage.transform.GetChild(0).            
            textImageData.text = "TESLA image - UPDATED to tracking";
        }

        foreach (var removedImage in eventArgs.removed)
        {
            // Handle removed event
            textImageData.text = "TESLA image - REMOVED to tracking";
        }
    }
    
//    void UpdateInfo(ARTrackedImage trackedImage)
//    {
//
//        if (trackedImage.trackingState != TrackingState.Tracking)
//        {
//
//            if(trackedImage.referenceImage.name == "ABC"){
//                Instantiate(prefab1, transform.position, transform.rotation);
//            }
//            else if(trackedImage.referenceImage.name == "XYZ"){
//                Instantiate(prefab2, transform.position, transform.rotation);
//            }
//
//        }else{
//            // Destroy object if you dont want to keep
//        }
//    }
//    
    
}