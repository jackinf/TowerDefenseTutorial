﻿using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 40000;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;

        Rounds = 0;
    }
}
