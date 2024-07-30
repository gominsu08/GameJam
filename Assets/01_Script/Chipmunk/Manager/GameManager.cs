using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public static bool isUnLoad = false;
    protected override void Awake()
    {
        base.Awake();
        SceneManager.sceneUnloaded += UnLoad;
        SceneManager.sceneLoaded += SceneLoad;

        InputReader.Instance.OnPlayer1Move += HorPlayerMove;
        InputReader.Instance.OnPlayer2Move += VerPlayerMove;
    }

    private void SceneLoad(Scene arg0, LoadSceneMode arg1)
    {
        isUnLoad = false;
    }

    private void UnLoad(Scene arg0)
    {
        Debug.Log("¾À ²ôÁü " + arg0);
        isUnLoad = true;
    }

    public void HorPlayerMove(Vector2 dir)
    {
        if (dir.x != 0)
            Enemy.enemies.ForEach(enemy => enemy.Move(dir));
    }
    public void VerPlayerMove(Vector2 dir)
    {
        if (dir.y != 0)
            Enemy.enemies.ForEach(enemy => enemy.Move(dir));
    }
}
