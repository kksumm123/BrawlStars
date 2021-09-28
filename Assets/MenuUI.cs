using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuUI : BaseUI<MenuUI>
{
    new void Awake()
    {
        base.Awake();
        transform.Find("PlayerInfoButton")
            .GetComponent<Button>().onClick
            .AddListener(() => OnClickPlayerInfoButton());
    }

    private void OnClickPlayerInfoButton()
    {
        PlayerInfoUI.Instance.ShowUI();
    }
}
