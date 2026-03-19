using System;
using UnityEngine;

public class Cheese: Collectible
{
    public int cheeseCounter { get; private set; } = 0;

    public override void ItemCollected(GameObject player)
    {
        cheeseCounter++;
        Destroy(this.gameObject);
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
