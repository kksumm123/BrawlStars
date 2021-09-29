using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public string selectedProfileName;
}
public class LocalDB : SingletonMonoBehaviour<LocalDB>
{
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
