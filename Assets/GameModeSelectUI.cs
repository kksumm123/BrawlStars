using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameModeSelectUI : MonoBehaviour
{
    ScrollRect scrollRect;
    Button[] downMenuButtons;
    void Start()
    {
        scrollRect = transform.Find("Scroll View").GetComponent<ScrollRect>();
        downMenuButtons = transform.Find("DownMenu").GetComponentsInChildren<Button>();
        for (int i = 0; i < downMenuButtons.Length; i++)
        {
            int index = i;
            var item = downMenuButtons[index];
            item.AddListener(this, () => OnClickDownMenu(index));

        }
    }

    void OnClickDownMenu(int index)
    {
        scrollRect.horizontalNormalizedPosition = (float)index / (downMenuButtons.Length - 1);
    }
}
