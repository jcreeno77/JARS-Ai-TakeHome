using UnityEngine;

public class ScaleCam_ByResolution : MonoBehaviour
{
    Camera cam;
    //Where to postiion cam in widescreen and phone screen
    [SerializeField] Vector3 widePos;
    [SerializeField] Vector3 phonePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cam.pixelWidth / cam.pixelHeight > .5f)
        {
            transform.position = widePos;
        }
        else
        {
            transform.position = phonePos;
        }
    }
}
