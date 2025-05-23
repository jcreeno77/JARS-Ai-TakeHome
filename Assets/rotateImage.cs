using UnityEngine;
using UnityEngine.UI;

public class rotateImage : MonoBehaviour
{
    [SerializeField] RawImage img;
    [SerializeField] float _x, _y = .1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(_x,_y) * Time.deltaTime, img.uvRect.size);
    }
}
