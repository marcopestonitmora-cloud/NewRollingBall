using System;
using UnityEngine;

public class Cheese: Collectible
{
    private PlayerInteractionSystem interaction;
    [SerializeField] private AudioClip eatCheese;
    [SerializeField] private float eatCheeseVolume = 5f;
    
    public override void ItemCollected(GameObject player)
    {
        interaction = player.GetComponent<PlayerInteractionSystem>();

        if (interaction != null)
        {
            AudioManager.instance.PlaySound(eatCheese,eatCheeseVolume);
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
