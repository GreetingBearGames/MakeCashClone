using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    //Player Cash
    public TextMeshProUGUI playerCash;
    // Income Button
    public TextMeshProUGUI incomeLevel;
    public TextMeshProUGUI incomeCash;
    // AddPipe
    public TextMeshProUGUI addPipeCash;
    //Speed Button
    public TextMeshProUGUI speedLevel;
    public TextMeshProUGUI speedCash;
    //Combine Button
    public TextMeshProUGUI combineCash;

    public GameObject CombineButton;

    public Slider gPUBar;
    public Slider giftBar;

    public List<TextMeshProUGUI> huniMultiplier;

    #region Action
    public static Action<float> SetPlayerCash;
    public static Action<float> IncomeCash;
    public static Action<int> IncomeLevel;
    public static Action<float> AddPipeCash;
    public static Action<float> SpeedCash;
    public static Action<int> SpeedLevel;
    public static Action<float> CombineCash;
    public static Action<int, string> HuniMultiplier;
    #endregion
    private void OnEnable()
    {
        SetPlayerCash += SetCash;
        IncomeCash += SetIncomeCash;
        IncomeLevel += SetIncomeLevel;
        AddPipeCash += SetAddPipeCash;
        SpeedCash += SetSpeedCash;
        SpeedLevel += SetSpeedLevel;
        CombineCash += SetCombineCash;
        GameManager.SetGiftCash += GiftBar;
        GameManager.SetGiftCashMax += GiftBarMax;
        HuniMultiplier += HuniMultiplierText;
    }
    void SetCash(float _cash)
    {
        playerCash.text = _cash.ToString();
    }
    void SetIncomeCash(float _cash)
    {
        incomeCash.text = _cash.ToString();
    }
    void SetIncomeLevel(int _level)
    {
        incomeLevel.text = _level.ToString();
    }
    void SetAddPipeCash(float _cash)
    {
        addPipeCash.text = _cash.ToString();
    }
    void SetSpeedCash(float _cash)
    {
        speedCash.text = _cash.ToString();
    }
    void SetSpeedLevel(int _level)
    {
        speedLevel.text = _level.ToString();
    }
    void SetCombineCash(float _cash)
    {
        combineCash.text = _cash.ToString();
    }
    public void CombineButtonActived(bool actived)
    {
        CombineButton.SetActive(actived);
    }

    public void GPUBar(int _value)
    {
        gPUBar.value = _value;
    }
    public void GPUBarMax(int _value)
    {
        gPUBar.maxValue = _value;
    }
    public void GiftBar(float _value)
    {
        giftBar.value = _value;
    }
    public void GiftBarMax(float _value)
    {
        giftBar.maxValue = _value;
    }
    public void HuniMultiplierText(int _count,string _text)
    {
        huniMultiplier[_count].text = _text;
    }

    private void OnDisable()
    {
        SetPlayerCash -= SetCash;
        IncomeCash -= SetIncomeCash;
        IncomeLevel -= SetIncomeLevel;
        AddPipeCash -= SetAddPipeCash;
        SpeedCash -= SetSpeedCash;
        SpeedLevel -= SetSpeedLevel;
        CombineCash -= SetCombineCash;
        GameManager.SetGiftCash -= GiftBar;
        GameManager.SetGiftCashMax -= GiftBarMax;
        HuniMultiplier += HuniMultiplierText;
    }
}
