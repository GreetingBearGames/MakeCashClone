using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefManager : MonoBehaviour
{
 

    public static float PlayerCash
    {
        get { return PlayerPrefs.GetFloat("PlayerCash",0f); }
        set { PlayerPrefs.SetFloat("PlayerCash", value); }
    }
    public static float GiftCash
    {
        get { return PlayerPrefs.GetFloat("GiftCash", 0f); }
        set { PlayerPrefs.SetFloat("GiftCash", value); }
    }
    public static int SpeedButtonLevel
    {
        get { return PlayerPrefs.GetInt("SpeedLevel",0); }
        set { PlayerPrefs.SetInt("SpeedLevel", value); }
    }
    public static int IncomeButtonLevel
    {
        get { return PlayerPrefs.GetInt("IncomeLevel", 0); }
        set { PlayerPrefs.SetInt("IncomeLevel", value); }
    }
    public static int AddPipeButtonLevel
    {
        get { return PlayerPrefs.GetInt("AddPipeLevel", 0); }
        set { PlayerPrefs.SetInt("AddPipeLevel", value); }
    }
    public static int CombineButtonLevel
    {
        get { return PlayerPrefs.GetInt("CombineLevel", 0); }
        set { PlayerPrefs.SetInt("CombineLevel", value); }
    }
    public static int GPUButtonLevel
    {
        get { return PlayerPrefs.GetInt("GPULevel", 0); }
        set { PlayerPrefs.SetInt("GPULevel", value); }
    }
    public static int TotalButtonLevel
    {
        get { return PlayerPrefs.GetInt("TotalLevel", 0); }
        set { PlayerPrefs.SetInt("TotalLevel", value); }
    }
    public static int GiftCashLevel
    {
        get { return PlayerPrefs.GetInt("GiftLevel", 0); }
        set { PlayerPrefs.SetInt("GiftLevel", value); }
    }
}
