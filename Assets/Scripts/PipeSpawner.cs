using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _heightRange = 0.45f;
    public GameObject _pipePrefab;

    private float _timer;
    public MovePipe _movePipe; // MovePipe nesnesine referans olu�turuyoruz
    private float _speed = 0.65f; // _speed de�i�kenini tan�ml�yoruz

    private void Start()
    {
        _movePipe = FindObjectOfType<MovePipe>(); // MovePipe nesnesini buluyoruz
        SpawnPipe();
    }

    private void Update()
    {
        if (_timer > _maxTime)
        {
            SpawnPipe();
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
        GameObject pipe = Instantiate(_pipePrefab, spawnPos, Quaternion.identity);

        if (_movePipe != null)
        {
            _movePipe.SetSpeed(_speed); // MovePipe nesnesinin _speed de�i�kenini g�ncelliyoruz
        }

        Destroy(pipe, 10f);
    }
}
