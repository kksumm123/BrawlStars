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
        transform.Find("CharaterSelectButton")
            .GetComponent<Button>().onClick
            .AddListener(OnClickChangeCharacter);
    }

    private void OnClickPlayerInfoButton()
    {
        PlayerInfoUI.Instance.ShowUI();
    }
    private void OnClickChangeCharacter()
    {
        CharacterSelectUI.Instance.ShowUI();
    }
}
