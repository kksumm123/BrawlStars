using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RawImageScroll : MonoBehaviour
{
    private RawImage rawImage;

    float curX = 0;
    float curY = 0;
    public Vector2 amount;

    private void Awake()
    {
        rawImage = GetComponent<RawImage>();
    }

    void Update()
    {
        curX += amount.x;
        curY += amount.y;
        rawImage.uvRect = new Rect(new Vector2(curX, curY), rawImage.uvRect.size);
    }
}
