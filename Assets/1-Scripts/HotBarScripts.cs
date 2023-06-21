using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotBarScripts : MonoBehaviour
{
    public Slider hotBar;

    public int hotBarValue = 0;
    public float speed;
    int increaseInt = 10;
    bool hotValueGPU = false;

    

    private void OnEnable()
    {
        GameManager.IncreaseHotBar += IncreaseHotBar;
        GameManager.DroppedHotBar += DroppingHotBar;
    }
    // Start is called before the first frame update
    void Start()
    {
        hotBar = gameObject.GetComponent<Slider>();
        hotBar.maxValue = 100;
        hotBar.value = hotBarValue;
    }

    private void Update()
    {
        if (hotBarValue != hotBar.value)
        {
            SetHotBar();
        }
        switch (hotBar.value)
        {
            case < 31:
                GameManager.Instance.Touched(true);
                break;
            case <71:
                GameManager.GPUColorChange(false);
                break;
            case < 81:
                GameManager.Instance.BurnGPU(false);
                GameManager.GPUColorChange(true);
                break;
            case < 91:
                GameManager.Instance.BurnGPU(true);
                
                break;
            case < 99:
                GameManager.Instance.LightningGpu(false);
                
                break;
            case < 110:
                GameManager.Instance.BurnGPU(false);
                GameManager.Instance.Touched(false);
                GameManager.Instance.LightningGpu(true);
                break;
        }
        
       
        
    }
    public void IncreaseHotBar()
    {
        if (hotBarValue <= hotBar.maxValue)
        {

            hotBarValue += 10;
        }
        
    }
    public void DroppingHotBar()
    {
        if (hotBarValue >= 0)
        {
            hotBarValue -= 10 ;
        }

    }

    void SetHotBar()
    {
        float _speed = speed;
        float _change = hotBarValue - hotBar.value;
        if (_change > 0)
        {
            _speed *= 1f;

        }
        else { _speed *= 5f; }
        hotBar.value += _change * Time.deltaTime * _speed;
    }
    private void OnDisable()
    {
        GameManager.IncreaseHotBar -= IncreaseHotBar;
        GameManager.DroppedHotBar -= DroppingHotBar;
    }

}
