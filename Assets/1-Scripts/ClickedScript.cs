using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClickedScript : MonoBehaviour
{
    public Transform huni;
    public GameObject[] spherify;
    public Renderer renderer;

    public int PipeMultiplier;
    float Defaultcash = 5;
    public float multiplierCash;

    GameManager gameManager;


    private void OnEnable()
    {

        GameManager.click += Click;
        GameManager.DefaultCash += CheckDefaultCash;


    }
    private void Start()
    {
        gameManager = GameManager.Instance;
        CheckDefaultCash();
    }

    public void Click()
    {

        multiplierCash = CashCalculation(Defaultcash);

        int selectCash = -1;
        switch (multiplierCash)
        {
            case < 100:
                selectCash = 0;
                break;
            case < 200:
                selectCash = 1;
                break;
            case < 1000:
                selectCash = 2;
                break;
            case < 1500:
                selectCash = 3;
                break;
            case < 2000:
                selectCash = 4;
                break;
            case < 3000:
                selectCash = 5;
                break;
            case < 70000:
                selectCash = 6;
                break;
            default:
                selectCash = -1;
                break;
        }

        var obj = GameManager.Instance.poolManager.GetPoolObject(selectCash);
        obj.transform.position = new Vector3(huni.transform.position.x, huni.transform.position.y - 0.2f, huni.transform.position.z);
        var textObj = Instantiate(GameManager.Instance.text, transform);
        textObj.gameObject.GetComponentInChildren<CashText>().multiplier = multiplierCash;
        textObj.transform.position = new Vector3(huni.transform.position.x, huni.transform.position.y + 0.3f, huni.transform.position.z + 0.2f);

        gameManager.AddPlayerCash(multiplierCash);
    }

    void CheckDefaultCash()
    {
        Defaultcash = gameManager.StartCash;
    }
    float CashCalculation(float _cash)
    {
        _cash = _cash * PipeMultiplier;
        return _cash;
    }


    private void OnDisable()
    {
        GameManager.click -= Click;
        GameManager.DefaultCash -= CheckDefaultCash;

    }
    public void ChangeColor(Color _color)
    {
        renderer.material.color = _color;
    }

}
