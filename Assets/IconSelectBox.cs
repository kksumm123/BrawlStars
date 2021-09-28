using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconSelectBox : MonoBehaviour
{
    public Image icon;
    void Start()
    {
        LinkComponent();
    }

    public void LinkComponent()
    {
        icon = transform.Find("Icon").GetComponent<Image>();
    }
}
