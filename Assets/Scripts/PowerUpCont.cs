using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCont : MonoBehaviour
{
    public struct PowerUp
    {
        public enum type
        {
            MULTIPLIER,
            IMMORTALITY,
            SPEEDRUN,
            TIMESHIFT
        }
        public type PowerUpType;
        public float Duration;
    }

    PowerUp[] PowerUps = new PowerUp[4];
    Coroutine[] PowerUpsCors = new Coroutine[4];
    public HeroScript hs;

    // Start is called before the first frame update
    void Start()
    {
        PowerUps[0] = new PowerUp() { PowerUpType = PowerUp.type.MULTIPLIER, Duration = 8 };
        PowerUps[1] = new PowerUp() { PowerUpType = PowerUp.type.IMMORTALITY, Duration = 8 };
        PowerUps[2] = new PowerUp() { PowerUpType = PowerUp.type.SPEEDRUN, Duration = 8 };
        PowerUps[3] = new PowerUp() { PowerUpType = PowerUp.type.TIMESHIFT, Duration = 8 };
    }

    void PowerUpUse(PowerUp.type type)
    {
        PowerUpReset(type);
        PowerUpsCors[(int)type] = StartCoroutine(PowerUpCor(type));

        switch(type)
        {
            case PowerUp.type.MULTIPLIER:
                hs.PowerUpMultiplier = 2;
                break;
            case PowerUp.type.IMMORTALITY:
                hs.ImmortalityOn();
                break;
            case PowerUp.type.SPEEDRUN:
                hs.ImmortalityOn();
                hs.PowerUpSpeed = 2;
                break;
            case PowerUp.type.TIMESHIFT:
                hs.PowerUpSpeed = 0.5f;
                break;
        }
    }

    public void ResetAllPowerUps()
    {
        for (int i = 0; i < PowerUps.Length; i++)
            PowerUpReset(PowerUps[i].PowerUpType);
    }

    void PowerUpReset(PowerUp.type type)
    {
        if (PowerUpsCors[(int)type] != null)
            StopCoroutine(PowerUpsCors[(int)type]);
        else
            return;

        PowerUpsCors[(int)type] = null;

        switch (type)
        {
            case PowerUp.type.MULTIPLIER:
                hs.PowerUpMultiplier = 1;
                break;
            case PowerUp.type.IMMORTALITY:
                hs.ImmortalityOff();
                break;
            case PowerUp.type.SPEEDRUN:
                hs.ImmortalityOff();
                hs.PowerUpSpeed = 1;
                break;
            case PowerUp.type.TIMESHIFT:
                hs.PowerUpSpeed = 1;
                break;
        }

    }

    IEnumerator PowerUpCor(PowerUp.type type)
    {
        float duration = PowerUps[(int)type].Duration;

        while(duration > 0)
        {
            duration -= Time.deltaTime;
            yield return null;
        }

        PowerUpReset(type);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Multiplier")
        {
            Destroy(col.gameObject);
            PowerUpUse(PowerUp.type.MULTIPLIER);
        }
        if (col.gameObject.tag == "Immortality")
        {
            Destroy(col.gameObject);
            PowerUpUse(PowerUp.type.IMMORTALITY);
        }
        if (col.gameObject.tag == "Timeshift")
        {
            Destroy(col.gameObject);
            PowerUpUse(PowerUp.type.TIMESHIFT);
        }
        if (col.gameObject.tag == "Speedrun")
        {
            Destroy(col.gameObject);
            PowerUpUse(PowerUp.type.SPEEDRUN);
        }
    }

   
}
