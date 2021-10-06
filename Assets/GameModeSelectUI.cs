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
        int selectedMenuIndex = 0;

        for (int i = downMenuButtons.Length - 1; i >= 0; i--)
        {
            var localPosX = scrollRect.content.GetChild(i).localPosition.x;
            var childWidth = scrollRect.content.GetChild(i).GetComponent<RectTransform>().sizeDelta.x * 0.5f;
            var contentWidth = scrollRect.content.GetComponent<RectTransform>().sizeDelta.x;
            float value = (localPosX - childWidth - (Screen.width * ((float)i / scrollRect.content.childCount))) / contentWidth;
            float scrollPosX = Mathf.Clamp(scrollPos.x, 0, 1);

            if (value < scrollPosX)
            {
                //selectedMenuIndex = Math.Min(i + 1, scrollRect.content.childCount - 1);
                selectedMenuIndex = Math.Max(i, 0);
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

    float childIndexPos;
    float normalPosition;
    bool scrollMovable = false;
    void OnClickDownMenu(int index)
    {
        childIndexPos = GetChildIndexPos(index);

        var contentWidth = scrollRect.content.GetComponent<RectTransform>().sizeDelta.x;
        normalPosition = childIndexPos / contentWidth;
        print($"i = {index}\n{childIndexPos} / {contentWidth} = {normalPosition}");

        normalPosition = Mathf.Clamp(normalPosition, 0, 1);
        scrollMovable = true;
    }
    float GetChildIndexPos(int index)
    {
        var localPosX = scrollRect.content.GetChild(index).localPosition.x;
        var childWidth = scrollRect.content.GetChild(index).GetComponent<RectTransform>().sizeDelta.x * 0.5f;
        var padding = scrollRect.content.GetComponent<HorizontalLayoutGroup>().padding.left;
        return localPosX - childWidth - padding;
    }
    [SerializeField] float lerpValue = 0.1f;
    void Update()
    {
        if (scrollMovable)
        {
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, normalPosition, lerpValue);

            var distanceX = Mathf.Abs(scrollRect.horizontalNormalizedPosition - normalPosition);
            if (Mathf.Abs(distanceX) < 0.01f)
                scrollMovable = false;
        }
    }
}
