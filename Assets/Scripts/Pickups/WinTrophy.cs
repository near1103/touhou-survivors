using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrophy : Pickup
{
    public override void Collect()
    {
        if (hasBeenCollected)
        {
            return;
        }
        else
        {
            base.Collect();
        }
        GameManager gm = FindObjectOfType<GameManager>();
        gm.GameOver();
    }
    void OnApplicationQuit()
    {
        Destroy(gameObject);
    }
}
