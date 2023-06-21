using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
   
    public GameObject Spawn(GameObject _prefab,GameObject _parentObject,Vector3 _position)
    {
        var _object = Instantiate(_prefab,_parentObject.transform);
        _object.transform.position = _position;
        return _object;
    }
    public GameObject Spawn(GameObject _prefab, GameObject _parentObject)
    {
        var _object = Instantiate(_prefab, _parentObject.transform);
        return _object;
    }
    public GameObject Spawn(GameObject _prefab)
    {
        var _object = Instantiate(_prefab);
        return _object;
    }
}
