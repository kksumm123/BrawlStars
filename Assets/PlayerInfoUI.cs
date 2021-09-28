using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : BaseUI<PlayerInfoUI>
{
    protected override void OnInit()
    {
        base.OnInit();
        transform.Find("ProfileChangeButton").GetComponent<Button>().onClick.AddListener(() => ProfileChangeButtonButton());
    }

    private void ProfileChangeButtonButton()
    {
        IconSelectUI.Instance.ShowUI();
    }

    public void ShowUI()
    {
        base.Show();
    }
}
