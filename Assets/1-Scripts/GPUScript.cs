using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
public class GPUScript : MonoBehaviour
{
    [Serializable]
   public struct GPU
    {
        public GameObject GPUPrefab;
        public Vector3 GPUPosition;
    }
    [SerializeField] public GPU[] gPU;

    public Color[] hotColor;
    public int activedGPU;
    public GameObject GPUPrefab;
    public Renderer rendererGPU;

    public List<Color> gPUDefaultColor;

    public bool ChangedColor = false;
    public bool HotValueBar = false;
    bool opened=false;

    public void OnEnable()
    {
        GameManager.ChangeGPU += IncreaseActivedGPU;
        GameManager.GPUColorChange += ChangeColor;
        GameManager.GPUColorClear += GPUDefaultColorClear;
    }
    
    private void Start()
    {
        activedGPU = GameManager.Instance.GPUButtonLevel;
        SetGPU();
        SetGPURenderer();
    }
    private void Update()
    {
        if (ChangedColor )
        {
            foreach (var _gpu in GPUPrefab.GetComponentsInChildren<Renderer>())
            {
                
                _gpu.material.color = Color.Lerp(_gpu.material.color, Color.red,Time.deltaTime);
            }
            HotValueBar = true;
            

        }
        else if (!ChangedColor && HotValueBar)
        {
            int i = 0;
            foreach (var _gpu in GPUPrefab.GetComponentsInChildren<Renderer>())
            {
                Debug.Log(i);
                Color _color = gPUDefaultColor[i];
                _gpu.material.color = Color.Lerp(_gpu.material.color, _color, Time.deltaTime);
                i++;
            }
            

        }
    }
    public void SetGPU()
    {
        Destroy(GPUPrefab);
        GPUPrefab =  GameManager.Instance.spawnScript.Spawn(gPU[activedGPU].GPUPrefab,this.gameObject,gPU[activedGPU].GPUPosition);
        StartCoroutine(CheckGPU());
      
        //SetGPURenderer();
    }
    IEnumerator CheckGPU()
    {
        yield return new WaitForSeconds(1f);
        foreach (var _gpu in GPUPrefab.GetComponentsInChildren<Renderer>())
        {
            gPUDefaultColor.Add(_gpu.material.color);

        }
    }

    public void IncreaseActivedGPU()
    {
        activedGPU++;
        SetGPU();
    }

    public void ChangeColor(bool _actived)
    {
        
        ChangedColor = _actived;
        
    }
    public void GPUDefaultColorClear()
    {
        gPUDefaultColor.Clear();
        
    }

    public void SetGPURenderer()
    {
        rendererGPU = GPUPrefab.GetComponent<Renderer>();
    }

    private void OnDisable()
    {
        GameManager.ChangeGPU -= IncreaseActivedGPU;
        GameManager.GPUColorChange -= ChangeColor;
        GameManager.GPUColorClear += GPUDefaultColorClear;
    }
}
