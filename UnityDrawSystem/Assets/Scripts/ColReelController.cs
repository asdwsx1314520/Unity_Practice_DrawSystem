using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColReelController : MonoBehaviour
{
    [Header("顯示主體")]
    public Image main;

    [Header("卡片資料庫")]
    public Sprite[] arr_mge;

    [Header("開始抽牌按鈕")]
    public Button btnStart;

    private List<int> arr_colReelValue = new List<int>();

    void Awake()
    {
        for (int i = 0; i < arr_mge.Length; i++)
        {
            arr_colReelValue.Add(i);
        }
    }

    /// <summary>
    /// 洗牌
    /// </summary>
    void shuffle()
    {
        for (int i = 0; i < arr_colReelValue.Count; i++)
        {
            int ran = Random.Range(0, arr_colReelValue.Count);
            int self = arr_colReelValue[i];
            arr_colReelValue[i] = arr_colReelValue[ran];
            arr_colReelValue[ran] = self;
        }
    }

    /// <summary>
    /// 開始滾動
    /// </summary>
    /// <param name="number">目標</param>
    /// <returns></returns>
    private IEnumerator start_rool(int number)
    {
        for (int i = 0; i < arr_colReelValue.Count; i++)
        {
            int value = arr_colReelValue[i];
            main.sprite = arr_mge[value];
            yield return new WaitForSeconds(0.1f);
        }

        for (int i = 0; i < arr_colReelValue.Count; i++)
        {
            int value = arr_colReelValue[i];
            main.sprite = arr_mge[value];
            if (value == number)
            {
                btnStart.interactable = true;
                yield break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    /// <summary>
    /// 開始抽牌
    /// </summary>
    public void btn_start()
    {
        btnStart.interactable = false;
        int art = Random.Range(0, arr_colReelValue.Count);
        shuffle();
        StartCoroutine(start_rool(art));
    }
}
