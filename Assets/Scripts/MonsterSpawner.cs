using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _monsterReference;
    
    [SerializeField] private Transform _leftPos, _rightPos;

    private GameObject _spawnedMonster;

    private int _randomIndex;
    
    private int _randomSide;

    private float _lastSpawned = 0f;

    private float _spawnInterval;

    private Pooling _pooling;
    // Start is called before the first frame update
    private void Start()
    {
        _pooling = FindObjectOfType<Pooling>();
        _spawnInterval = Random.Range(1, 5);
    }
    
    // Update is called once per frame
    private void Update()
    {
        _lastSpawned += Time.deltaTime;
        if (_lastSpawned >= _spawnInterval)
        {
            SpawnMonsters();
            _lastSpawned = 0f;
            _spawnInterval = Random.Range(1, 5);
        }
    }

    private void SpawnMonsters()
    {
        _randomIndex = Random.Range(0, _monsterReference.Length);
        _randomSide = Random.Range(0, 2);
        // _spawnedMonster = Instantiate(_monsterReference[_randomIndex]); 
        GameObject monsterPrefab = _monsterReference[_randomIndex];      
        GameObject _spawnedMonster = _pooling.GetObject(monsterPrefab);
        if (_randomSide == 0)
        {
            _spawnedMonster.transform.position = _leftPos.position;
            _spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
        }
        else
        {
            _spawnedMonster.transform.position = _rightPos.position;
            _spawnedMonster.GetComponent<Monster>().speed = -(Random.Range(4, 10));
            _spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
