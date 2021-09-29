using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindUserScene : MonoBehaviour
{
    Text searchResultText;
    public float findUserTime = 3;
    IEnumerator Start()
    {
        searchResultText = GameObject.Find("Canvas/FindUserScene/SearchResultText").GetComponent<Text>();

        //3초 동안 1 ~ 10으로 까지 숫자를 올린 다음
        // 로딩 UI를 불러오고 FindUserUI는 꺼지게 해라.

        float startTime = Time.time;
        float endTime = Time.time + findUserTime;
        while (Time.time < endTime)
        {
            float passedTime = Time.time - startTime;
            int findUser = Mathf.RoundToInt(Mathf.Lerp(0, 10, passedTime / 3));
            searchResultText.text = $"찾은 플레이어:{findUser}/10";
            yield return null;
        }

        Debug.Log("Loading UI표시하자.");
        loadingUIs.ForEach(x => x.SetActive(true));
        gameObject.SetActive(false);
    }
    public List<GameObject> loadingUIs;
}
