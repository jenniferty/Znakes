//adapted script from llamacademy https://github.com/llamacademy/flamethrower/blob/main/Assets/Scripts/FlamethrowerAttackRadius.cs
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Collider))]
[DisallowMultipleComponent]
public class FlamethrowerAttackRadius : MonoBehaviour
{
    public delegate void PlayerEnteredEvent(PlayerHealthController player);
    public delegate void PlayerExitedEvent(PlayerHealthController player);
    public event PlayerEnteredEvent OnPlayerEnter;
    public event PlayerEnteredEvent OnPlayerExit;
    private float tickTime = 0.3f; //changes frequency of damage
    private List<PlayerHealthController> PlayersInRadius = new List<PlayerHealthController>();


    void Start()
    {

    }
    void StartDamage()
    {
        StartCoroutine(dps());
    }
    private IEnumerator dps()
    {
        //waits a set time before invoking damage
        yield return new WaitForSeconds(getTickTime());
        //checks if exists and not null or zero
        if ((PlayersInRadius?.Count ?? 0) != 0)
        {
            //access script of first component in list only
            if (PlayersInRadius.First() != null)
            {
                PlayerHealthController player = PlayersInRadius.First();
                player.GetComponent<PlayerHealthController>().TakeDamage(1);
            }
            //only if playerhealthcontroller list has items
            Invoke("StartDamage", 0);
        }
    }
    //adds component to list
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerHealthController>(out PlayerHealthController player))
        {
            PlayersInRadius.Add(player);
            OnPlayerEnter?.Invoke(player);
            Invoke("StartDamage", 0);
        }
    }
    //removes from list when exits
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerHealthController>(out PlayerHealthController player))
        {
            PlayersInRadius.Remove(player);
            OnPlayerExit?.Invoke(player);
        }
    }
    //when enemy object is destroyed clear list
    private void OnDisable()
    {
        foreach (PlayerHealthController player in PlayersInRadius)
        {
            OnPlayerExit?.Invoke(player);
        }

        PlayersInRadius.Clear();
    }
    public float getTickTime()
    {
        return this.tickTime;
    }
}