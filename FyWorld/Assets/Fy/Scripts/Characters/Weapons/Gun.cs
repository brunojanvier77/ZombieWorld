using Fy.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun 
{
    public Human owner;

    public int poolSize = 100;
    public float fireRate = 0.05f;
    public float damage = 0.5f;
    public float accuracy = 0.5f;

    float timer = 0.0f;
    private Human human;

    public Gun(Human human)
    {
        this.owner = human;
    }

    internal void Shoot(Zombie target)
{
        timer += Time.deltaTime;
        if (timer > fireRate)
        {
            target.GetDamage(50);
            timer = 0.0f;
        }
    }

    internal void LevelUp(float nextDamage, float nextFirerate, float nextAccuracy)
    {
        this.fireRate = nextFirerate;
        this.damage = nextDamage;
        this.accuracy = nextAccuracy;
    }
}
