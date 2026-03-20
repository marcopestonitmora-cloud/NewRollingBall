using UnityEngine;

public class Clock : Collectible
{
    private ClockTimer timeBoost;
    [SerializeField] private AudioClip clockBoost;
    [SerializeField] private float clockBoostVolume = 5f;
    
    public override void ItemCollected(GameObject player)
    {
        timeBoost = player.GetComponent<ClockTimer>();

        if (timeBoost != null)
        {
            AudioManager.instance.PlaySound(clockBoost,clockBoostVolume);
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
