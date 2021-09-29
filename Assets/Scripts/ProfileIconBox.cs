using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileIconBox : MonoBehaviour
{
    public Image icon;
    public Button button;
    void Start()
    {
        LinkComponent();
    }

    public void LinkComponent()
    {
        icon = transform.Find("Icon").GetComponent<Image>();
        button = GetComponent<Button>();
    }
}
