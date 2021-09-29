using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectUI : BaseUI<CharacterSelectUI>
{
    Image baseItem;
    protected override void OnInit()
    {
        base.OnInit();
        baseItem = transform.Find("CharacterSelectUI/Scroll View/Viewport/Content/UnLockedCharecter/Item").GetComponent<Image>();
    }
}
