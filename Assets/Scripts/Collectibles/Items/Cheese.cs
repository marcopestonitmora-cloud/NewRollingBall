using System;
using UnityEngine;

public class Cheese: Collectible
{
    private PlayerInteractionSystem interaction;
    
    public override void ItemCollected(GameObject player)
    {
        interaction = player.GetComponent<PlayerInteractionSystem>();

        if (interaction != null)
        {
            interaction.AddCheese();
        }

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
