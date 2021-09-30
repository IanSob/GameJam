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
        float itemAsp = xScale / yScale;
        

        if (xScale > camhor)
        {
            Cam.orthographicSize = Mathf.Ceil(yScale / 2 * (itemAsp / Cam.aspect) + 1);
        }
        else if(itemAsp < Cam.aspect)
        {
            Cam.orthographicSize = Mathf.Ceil(yScale / 2 + 1);
        }
        CamObj.transform.position = position;
    }
}
