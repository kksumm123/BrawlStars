using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedProfileIcon : ListItemMonobehaviour<SelectedProfileIcon>
{
    public Image icon;
    new void Awake()
    {
        base.Awake();
        icon = transform.Find("Icon").GetComponent<Image>();
    }
    private void Start()
    {
        Refresh();
    }

    internal void Refresh()
    {
        string iconName = LocalDB.Instance.player.data.selectedProfileName;
        icon.sprite = LocalDB.Instance.profileIcons.Find(x => x.name == iconName);
    }
}
