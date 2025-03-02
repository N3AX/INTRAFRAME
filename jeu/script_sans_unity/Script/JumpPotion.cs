using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using UnityEngine;

public class JumpPotion : MonoBehaviour
{
    public float jumpBoostAmount = 3f; 
    public float boostDuration = 7f; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Potion de saut ramassée !");
            MovementPlayer playerMovement = other.GetComponent<MovementPlayer>();
            if (playerMovement != null)
            {
                StartCoroutine(BoostJump(playerMovement));
            }
            gameObject.SetActive(false); 
        }
    }

    IEnumerator BoostJump(MovementPlayer player)
    {
        player.jumpf *= jumpBoostAmount; 
        yield return new WaitForSeconds(boostDuration); 
        player.jumpf /= jumpBoostAmount; 
        
        Destroy(gameObject); 
    }
}


