using UnityEngine;

public class Clock : Collectible
{
    private ClockTimer timeBoost;
    
    public override void ItemCollected(GameObject player)
    {
        timeBoost = player.GetComponent<ClockTimer>();

        if (timeBoost != null)
        {
            timeBoost.MoreTime();
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
