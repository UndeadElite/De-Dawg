using UnityEngine;

public class ResetCamera : MonoBehaviour
{
    private Vector3 cachedPosition;
    private Quaternion cachedRotation;

    public void CacheCamera(Camera cam)
    {
        cachedPosition = cam.transform.position;
        cachedRotation = cam.transform.rotation;
    }

    public void ResetCameraInfo(Camera cam)
    {
        cam.transform.position = cachedPosition;
        cam.transform.rotation = cachedRotation;
        cam.fieldOfView = 60;
    }

}
