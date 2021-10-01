using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Button>().AddListener(this, StartPunchAnimation);
    }

    public float strength = 0.1f;
    public float duration = 0.5f;
    public int vibrato = 10;
    private void StartPunchAnimation()
    {
        transform.DOPunchScale(Vector3.one * strength, duration, vibrato);
    }

#if UNITY_EDITOR
    [ContextMenu("모든 버튼에 버튼애니메이션 스크립트 붙이기")]
    void AllAddButtonAnimation()
    {
        Button[] allButtons = FindObjectsOfType<Button>(true);
        foreach (var item in allButtons)
        {
            if (item.GetComponent<ButtonAnimation>() != null)
                continue;

            item.gameObject.AddComponent<ButtonAnimation>();

            UnityEditor.EditorUtility.SetDirty(item.gameObject);
        }
    }


    [ContextMenu("모든 버튼 설정을 현재 버튼 설정값으로 수정")]
    void ChangeValueButtonAnimation()
    {
        ButtonAnimation[] allButtons = FindObjectsOfType<ButtonAnimation>(true);
        foreach (var item in allButtons)
        {
            item.strength = strength;
            item.duration = duration;
            item.vibrato = vibrato;
            UnityEditor.EditorUtility.SetDirty(item.gameObject);
        }
    }


    [ContextMenu("선택한 버튼들의 설정을 현재 버튼 설정값으로 수정")]
    void ChangeValueSelectedButtonAnimation()
    {
        // 자식 포함 안하는 버전
        foreach (UnityEngine.Object obj in UnityEditor.Selection.objects)
        {
            GameObject go = (GameObject)obj;
            if (go == null)
                continue;

            var item = go.GetComponent<ButtonAnimation>();
            item.strength = strength;
            item.duration = duration;
            item.vibrato = vibrato;
            UnityEditor.EditorUtility.SetDirty(item.gameObject);
        }
    }

    [ContextMenu("선택한 버튼과 자식 포함한 버튼들의 설정을 현재 버튼 설정값으로 수정")]
    void ChangeValueSelectedAndChildsButtonAnimation()
    {
        // 자식 포함하는 버전.
        HashSet<ButtonAnimation> checkedButton = new HashSet<ButtonAnimation>();
        foreach (UnityEngine.Object obj in UnityEditor.Selection.objects)
        {
            if ((obj is GameObject) == false)
                continue;

            GameObject go = obj as GameObject;
            ButtonAnimation[] buttons = go.GetComponentsInChildren<ButtonAnimation>(true);
            foreach (var item in buttons)
            {
                if (checkedButton.Contains(item))
                {
                    //Debug.Log("이미 체크 했음" + item.name);
                    continue;
                }
                checkedButton.Add(item);
                item.strength = strength;
                item.duration = duration;
            }
        }
    }
#endif
}
