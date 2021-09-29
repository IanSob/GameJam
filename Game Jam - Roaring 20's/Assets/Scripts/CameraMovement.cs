using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject CamObj;
    public Camera Cam;
    private float camhor;

    // Start is called before the first frame update
    void Start()
    {
        camhor = Cam.aspect * Cam.orthographicSize;
    }

    public void SetCam(Vector3 position, float xScale, float yScale)
    {
        
        camhor = Cam.aspect * (Cam.orthographicSize * 2);
        Debug.Log(camhor);

        if (xScale > camhor)
        {
            Cam.orthographicSize = Mathf.Ceil(yScale / 2 + xScale - camhor + 2);
        }
        else
        {
            Cam.orthographicSize = Mathf.Ceil(yScale / 2 + 2);
        }
        CamObj.transform.position = position;
    }
}
