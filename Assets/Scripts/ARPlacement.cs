using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacement : MonoBehaviour
{
    public GameObject targetMarker;

    public ARRaycastManager arRaycastManager;

    public GameObject spider;

    private void Update()
    {
        var x = Screen.width / 2;
        var y = Screen.height / 2;

        var screenCenter = new Vector2(x, y);

        var hitResults = new List<ARRaycastHit>();

        arRaycastManager.Raycast(screenCenter, hitResults, TrackableType.PlaneWithinBounds);

        if (hitResults.Count > 0)
        {
            // transform.position = hitResults[0].pose.position;
            // transform.rotation = hitResults[0].pose.rotation;

            transform.SetPositionAndRotation(
                hitResults[0].pose.position,
                hitResults[0].pose.rotation
            );

            if (!targetMarker.activeSelf)
            {
                targetMarker.SetActive(true);
            }
        }

        if (Input.GetMouseButtonDown(0) && targetMarker.activeSelf)
        {
            var spiderClone = Instantiate(spider, transform.position, transform.rotation);

            var randomRotation = Random.Range(0f, 360f);
            spiderClone.transform.Rotate(Vector3.up * randomRotation);

            spiderClone.SetActive(true);

            // spider.transform.SetPositionAndRotation(transform.position, transform.rotation);
            //
            // if (!spider.activeSelf)
            // {
            //     spider.SetActive(true);
            // }
        }
    }
}
