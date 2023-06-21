using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class CashText : MonoBehaviour
{
    // Start is called before the first frame update
    public float multiplier = 1;
    
    void Start()
    {
 
        gameObject.GetComponent<TextMeshProUGUI>().text = multiplier.ToString();
        gameObject.transform.DOMove(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.3f, gameObject.transform.position.z), 1f);
        Destroy(gameObject,1);
    }
}
