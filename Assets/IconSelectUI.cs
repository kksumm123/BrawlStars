using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconSelectUI : BaseUI<IconSelectUI>
{
    public List<Sprite> icons = new List<Sprite>();
    IconSelectBox baseIconSelectBox;
    List<IconSelectBox> iconSelectBoxs = new List<IconSelectBox>();
    protected override void OnInit()
    {
        base.OnInit();
        baseIconSelectBox = GetComponentInChildren<IconSelectBox>(true);

        iconSelectBoxs.ForEach(x => Destroy(x.gameObject));
        iconSelectBoxs.Clear();

        baseIconSelectBox.gameObject.SetActive(true);
        foreach (var item in icons)
        {
            var newItem = Instantiate(baseIconSelectBox, baseIconSelectBox.transform.parent);
            newItem.LinkComponent();
            newItem.icon.sprite = item;
            iconSelectBoxs.Add(newItem);
        }
        baseIconSelectBox.gameObject.SetActive(false);
    }

    internal void ShowUI()
    {
        base.Show();
    }
}
