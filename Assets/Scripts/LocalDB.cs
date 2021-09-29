using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public string selectedProfileName;

    internal void SetSeletedProfileName(string selectedSpriteName)
    {
        selectedProfileName = selectedSpriteName;

        // 모든 SelectedProfileIcon 아이콘 교체
        SelectedProfileIcon.Items.ForEach(x => x.Refresh());
    }
}
public class LocalDB : SingletonMonoBehaviour<LocalDB>
{
    public List<Sprite> profileIcons = new List<Sprite>();

    public FileData<PlayerData> player;

    protected override void OnInit()
    {
        base.OnInit();
        player = new FileData<PlayerData>("PlayerData");
    }
    new private void OnDestroy()
    {
        base.OnDestroy();
        player.SaveData();
    }
}
