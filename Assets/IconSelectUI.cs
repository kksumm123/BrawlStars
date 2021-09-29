﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconSelectUI : BaseUI<IconSelectUI>
{
    public List<Sprite> icons = new List<Sprite>();
    ProfileIconBox baseProfileIconBox;
    List<ProfileIconBox> profileIconBoxs = new List<ProfileIconBox>();
    protected override void OnInit()
    {
        base.OnInit();
        baseProfileIconBox = GetComponentInChildren<ProfileIconBox>(true);

        profileIconBoxs.ForEach(x => Destroy(x.gameObject));
        profileIconBoxs.Clear();

        baseProfileIconBox.gameObject.SetActive(true);
        foreach (var item in icons)
        {
            var newIconItem = Instantiate(baseProfileIconBox, baseProfileIconBox.transform.parent);
            newIconItem.LinkComponent();
            newIconItem.icon.sprite = item;
            newIconItem.button.onClick.AddListener(() => OnClickItem(newIconItem));
            profileIconBoxs.Add(newIconItem);
        }
        baseProfileIconBox.gameObject.SetActive(false);
    }

    private void OnClickItem(ProfileIconBox newIconItem)
    {
        string selectedSpriteName = newIconItem.icon.name;
        LocalDB.Instance.player.data.SetSeletedProfileName(selectedSpriteName);
    }

    internal void ShowUI()
    {
        base.Show();
    }
}
