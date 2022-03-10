using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]

public class Resize_Sprite : MonoBehaviour
{

    /// <summary> Do you want the sprite to maintain the aspect ratio? </summary>
    public bool keepAspectRatio = true;
    /// <summary> Do you want it to continually check the screen size and update? </summary>
    public bool ExecuteOnUpdate = true;

    void Start()
    {
        Resize(keepAspectRatio);
    }

    void FixedUpdate()
    {
        if (ExecuteOnUpdate)
            Resize(keepAspectRatio);
    }

    /// <summary>
    /// Resize the attached sprite according to the camera view
    /// </summary>
    /// <param name="keepAspect">bool : if true, the image aspect ratio will be retained</param>
    void Resize(bool keepAspect = false)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        float screenWidth = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        transform.localScale = Vector3.one * screenWidth;
    }
}
