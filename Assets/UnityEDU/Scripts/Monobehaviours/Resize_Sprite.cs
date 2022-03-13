using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]

public class Resize_Sprite : MonoBehaviour
{

    /// <summary> Do you want the sprite to maintain the aspect ratio? </summary>
    public bool keepAspectRatio = true;
    /// <summary> Do you want it to continually check the screen size and update? </summary>
    public bool ExecuteOnUpdate = false;

    private SpriteRenderer sr;
    
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
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
        

        Vector3 screenboundsLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
        Vector3 screenboundsRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0));
        
        
        Vector3 screenboundsTop = Camera.main.ViewportToWorldPoint(new Vector3(0, 1));
        Vector3 screenboundsBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));


        Vector3 screenwidth = screenboundsRight - screenboundsLeft;

        Vector3 screenheight = screenboundsTop - screenboundsBottom;

        
        Sprite background = sr.sprite;
        
        
        float xsize = background.bounds.extents.x * 2;
        float ysize = background.bounds.extents.y * 2;
        
        
        float horizontalratio = screenwidth.x / xsize;

        float verticalratio = screenheight.y / ysize;
        
        
        sr.transform.localScale = new Vector3(horizontalratio, verticalratio);
        
    }
    
}
