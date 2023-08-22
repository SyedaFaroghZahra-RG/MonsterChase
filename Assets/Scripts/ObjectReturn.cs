using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReturn : MonoBehaviour
{
    private Pooling _objectPool;
    // Start is called before the first frame update
    void Start()
    {
        _objectPool = FindObjectOfType<Pooling>();
    }

    private void OnDisable()
    {
        if (_objectPool != null)
        {
            _objectPool.ReturnGameObject(this.gameObject);
        }
    }
}
