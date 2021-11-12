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
        transform.Find("PlayButton/Button")
            .GetComponent<Button>().onClick
            .AddListener(OnClickPlay);
        transform.Find("GemGrapButton/Button")
            .GetComponent<Button>().onClick
            .AddListener(OnClickGameModeSelect);
    }

    void OnClickGameModeSelect()
    {
        GameModeSelectUI.Instance.ShowUI();
    }

    void OnClickPlay()
    {
        FindUserScene.Instance.ShowUI();
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
