using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectUI : BaseUI<CharacterSelectUI>
{
    GameObject baseItem;
    Image baseItemIcon;
    public Transform unlockedParent;
    public Transform lockedParent;
    protected override void OnInit()
    {
        base.OnInit();
        gameObject.SetActive(true);
        unlockedParent = transform.Find("Scroll View/Viewport/Content/UnLockedCharecters");
        lockedParent = transform.Find("Scroll View/Viewport/Content/LockedCharecters");
        baseItem = transform.Find("Scroll View/Viewport/Content/UnLockedCharecters/BaseItem").gameObject;
        baseItemIcon = baseItem.transform.Find("Icon").GetComponent<Image>();

        var unlockedIDs = LocalDB.Instance.player.data.unlockedBrawlerIDs;
        var lockedIDs = LocalDB.Instance.player.data.lockedBrawlerIDs;

        baseItem.gameObject.SetActive(true);

        foreach (var item in unlockedIDs)
        {
            var newItem = Instantiate(baseItem, unlockedParent);
            string spriteName = item.ToString();
            var newItemImage = newItem.transform.Find("Icon").GetComponent<Image>();
            newItemImage.sprite = LocalDB.Instance.brawlerIcons.Find(x => x.name == spriteName);
            newItemImage.material = new Material(baseItemIcon.material);
            newItemImage.material.SetFloat("_Saturation", 1);
        }
        foreach (var item in lockedIDs)
        {
            var newItem = Instantiate(baseItem, lockedParent);
            string spriteName = item.ToString();
            var newItemImage = newItem.transform.Find("Icon").GetComponent<Image>();
            newItemImage.sprite = LocalDB.Instance.brawlerIcons.Find(x => x.name == spriteName);
            newItemImage.material = new Material(baseItemIcon.material);
            newItemImage.material.SetFloat("_Saturation", 0);
        }

        StartCoroutine(ContentSizeFitterRebuildCo());

        baseItem.gameObject.SetActive(false);
    }
    internal void ShowUI()
    {
        base.Show();
    }

    IEnumerator ContentSizeFitterRebuildCo()
    {
        yield return null;
        var csfs = GetComponentsInChildren<ContentSizeFitter>().ToList();

        foreach (var item in csfs)
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)item.transform);
    }
}
