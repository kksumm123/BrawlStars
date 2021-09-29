using System;
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
            var newItem = Instantiate(baseProfileIconBox, baseProfileIconBox.transform.parent);
            newItem.LinkComponent();
            newItem.icon.sprite = item;
            profileIconBoxs.Add(newItem);
        }
        baseProfileIconBox.gameObject.SetActive(false);
    }

    internal void ShowUI()
    {
        base.Show();
    }
}
