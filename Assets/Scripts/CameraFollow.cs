using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform _player;
    private Vector3 _tempPos;
    [SerializeField] private float _minX, _maxX;
    private void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (!_player)
            return;
        
        _tempPos = transform.position;
        _tempPos.x = _player.position.x;

        if (_tempPos.x < _minX)
            _tempPos.x = _minX;
        if (_tempPos.x > _maxX)
            _tempPos.x = _maxX;
        
        transform.position = _tempPos;
    }
}
