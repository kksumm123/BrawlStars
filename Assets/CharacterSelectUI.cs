using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectUI : BaseUI<CharacterSelectUI>
{
    GameObject baseItem;
    public Transform unlockedParent;
    public Transform lockedParent;
    protected override void OnInit()
    {
        base.OnInit();
        unlockedParent = transform.Find("Scroll View/Viewport/Content/UnLockedCharecter");
        lockedParent = transform.Find("Scroll View/Viewport/Content/LockedCharecter");
        baseItem = transform.Find("Scroll View/Viewport/Content/UnLockedCharecter/BaseItem").gameObject;

        var unlockedIDs = LocalDB.Instance.player.data.unlockedBrawlerIDs;
        var lockedIDs = LocalDB.Instance.player.data.lockedBrawlerIDs;

        baseItem.gameObject.SetActive(true);

        foreach (var item in unlockedIDs)
        {
            var newItem = Instantiate(baseItem, unlockedParent);
            string spriteName = item.ToString();
            newItem.transform.Find("Icon").GetComponent<Image>().sprite = LocalDB.Instance.brawlerIcons.Find(x => x.name == spriteName);
        }
        foreach (var item in lockedIDs)
        {
            var newItem = Instantiate(baseItem, lockedParent);
            string spriteName = item.ToString();
            newItem.transform.Find("Icon").GetComponent<Image>().sprite = LocalDB.Instance.brawlerIcons.Find(x => x.name == spriteName);
        }

        Invoke(nameof(LatedUpdateIVK), 0);
        //StartCoroutine(ContentSizeFitterRebuildCo());

        baseItem.gameObject.SetActive(false);
    }
    private void LatedUpdateIVK()
    {
        StartCoroutine(ContentSizeFitterRebuildCo());
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
