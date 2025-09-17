using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Health _health;
    [SerializeField] private Score _score;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private List<BulletSpawner> _bulletSpawners;
    [SerializeField] private StartWindow _startWindow;
    [SerializeField] private EndGameWindow _endGameWindow;
    [SerializeField] private float _endGameDeley;

    private Coroutine _endGameCorutine;

    private void Start()
    {
        PauseGame();
    }

    private void OnEnable()
    {
        _startWindow.PlayButtonClicked += OnPlayButtonClick;
        _endGameWindow.RestartButtonClicked += OnRestartButtonClick;
        _health.Died += EndGame;
    }

    private void OnDisable()
    {
        _startWindow.PlayButtonClicked -= OnPlayButtonClick;
        _endGameWindow.RestartButtonClicked -= OnRestartButtonClick;
        _health.Died -= EndGame;
    }

    private void EndGame()
    {
        if (_endGameCorutine == null)
            _endGameCorutine = StartCoroutine(EndGameCorutine());
    }

    public IEnumerator EndGameCorutine()
    {
        var waitForSeconds = new WaitForSeconds(_endGameDeley);

        yield return waitForSeconds;

        _endGameWindow.Open();
        PauseGame();
    }

    private void OnRestartButtonClick()
    {
        _endGameWindow.Close();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startWindow.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1.0f;
        _enemySpawner.Reset();
        _player.Reset();
        _score.Reset();
        _enemySpawner.StartSpawn();

        foreach(BulletSpawner bulletSpawner in _bulletSpawners)
            bulletSpawner.Reset();

        if (_endGameCorutine != null)
        {
            StopCoroutine(_endGameCorutine);
            _endGameCorutine = null;
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        _enemySpawner.OffSpawn();
    }
}
