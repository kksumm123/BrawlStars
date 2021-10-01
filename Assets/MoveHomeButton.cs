using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveHomeButton : MonoBehaviour
{
    void Start()
    {
        Button button = transform.AddOrGetComponent<Button>();
        button.AddListener(this, MoveHome);
    }

    private void MoveHome()
    {
        // MenuUI를 제외한 다른 UI들을 모두 닫는다.
        while (UIStackManager.uICloserStack.Count > 1)
        {
            UIStackManager.Instance.MoveBack();
        }
    }
}
