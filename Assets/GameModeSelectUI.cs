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

        scrollRect.onValueChanged.AddListener(OnGameModeScrollValueChanged);


        SetAactiveMenuText(0);
    }

    private void OnGameModeScrollValueChanged(Vector2 scrollPos)
    {
        float x = scrollPos.x;

        int selectedMenuIndex = 0;

        for (int i = downMenuButtons.Length - 1; i >= 0; i--)
        {
            float value = (float)i / downMenuButtons.Length;
            if (value < x)
            {
                selectedMenuIndex = i;
                break;
            }
        }

        SetAactiveMenuText(selectedMenuIndex);
    }

    int lastSelectedIndex;
    public Color selectedTitleColor = Color.yellow;
    private void SetAactiveMenuText(int selectedMenuIndex)
    {
        downMenuButtons[lastSelectedIndex].GetComponentInChildren<Text>().color = Color.white;
        downMenuButtons[selectedMenuIndex].GetComponentInChildren<Text>().color = selectedTitleColor;
        lastSelectedIndex = selectedMenuIndex;
    }

    float childIndexPosX;
    bool normalMovable = false;
    float normalValue;
    bool scrollMovable = false;
    void OnClickDownMenu(int index)
    {
        scrollMovable = false;
        normalMovable = false;

        if (scrollRect.content.GetChild(index) != null)
        {
            childIndexPosX = scrollRect.GetComponent<RectTransform>().sizeDelta.x * 0.5f
                - scrollRect.content.GetChild(index).localPosition.x;

            if (index == 0)
            {
                normalMovable = true;
                normalValue = 0;

            }
            else if (index == scrollRect.content.childCount - 1)
            {
                normalMovable = true;
                normalValue = 1;
            }
            else
            {
                scrollMovable = true;
            }
        }
    }

    float addedLerpValue;
    [SerializeField] float lerpValue = 0.1f;
    void Update()
    {
        if (scrollMovable)
        {
            addedLerpValue += lerpValue * 0.1f;

            var curPosX = scrollRect.content.position.x;

            var distanceX = Mathf.Abs(curPosX) - Mathf.Abs(childIndexPosX);
            if (Mathf.Abs(distanceX) < 50)
            {
                scrollMovable = false;
            }
            else
            {
                var pos = scrollRect.content.position;
                pos.x = Mathf.Lerp(curPosX, childIndexPosX, addedLerpValue);
                scrollRect.content.position = pos;
            }
        }
        else if (normalMovable)
        {
            addedLerpValue += lerpValue * 0.1f;

            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, normalValue, addedLerpValue);

            var distanceX = Mathf.Abs(scrollRect.horizontalNormalizedPosition) - Mathf.Abs(normalValue);
            if (Mathf.Abs(distanceX) < 0.01f)
                normalMovable = false;
        }
        else
        {
            addedLerpValue = 0;
        }
    }
}
