using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroy : MonoBehaviour
{
    public int ObjectType;
    private void OnEnable()
    {
        StartCoroutine(CoinDestroyer());
        
    }

    IEnumerator CoinDestroyer()
    {
        yield return new WaitForSeconds(2);
        
        GameManager.Instance.poolManager.SetPoolObject(gameObject,ObjectType);
    }
}
