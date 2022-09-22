//adapted script from llamacademy https://github.com/llamacademy/flamethrower/blob/main/Assets/Scripts/FlamethrowerAttackRadius.cs
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Collider))]
[DisallowMultipleComponent]
public class FlamethrowerAttackRadius : MonoBehaviour
{
    public delegate void PlayerEnteredEvent(PlayerController player);
    public delegate void PlayerExitedEvent(PlayerController player);
    public event PlayerEnteredEvent OnPlayerEnter;
    public event PlayerEnteredEvent OnPlayerExit;

    private List<PlayerController> PlayersInRadius = new List<PlayerController>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            PlayersInRadius.Add(player);
            OnPlayerEnter?.Invoke(player);
            Invoke("StartDamage", 0);
        }
    }

    void Start(){
    }
    void StartDamage(){
        StartCoroutine(dps());
    }
    private IEnumerator dps(){
        yield return new WaitForSeconds( 0.1f );
        if((PlayersInRadius?.Count ?? 0) != 0){
            if(PlayersInRadius.First() != null){
                PlayerController player = PlayersInRadius.First();
                //float minTimeToDamage = 1f / 3f;
                //int damagePerTick = Mathf.FloorToInt(minTimeToDamage);
        
                player.GetComponent<PlayerController>().TakeDamage(3);
            }
        Invoke("StartDamage", 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if(other.TryGetComponent<PlayerController>())
        if (other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            PlayersInRadius.Remove(player);
            OnPlayerExit?.Invoke(player);
        }
    }

    private void OnDisable()
    {
        foreach (PlayerController player in PlayersInRadius)
        {
            OnPlayerExit?.Invoke(player);
        }

        PlayersInRadius.Clear();
    }
}