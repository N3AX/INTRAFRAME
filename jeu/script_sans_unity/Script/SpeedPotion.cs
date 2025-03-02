using System.Collections;
using UnityEngine;

public class SpeedPotion : MonoBehaviour
{
    public float boostAmount = 2f; 
    public float boostDuration = 7f; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            MovementPlayer playerMovement = other.GetComponent<MovementPlayer>();
            if (playerMovement != null)
            {
                StartCoroutine(BoostSpeed(playerMovement));
            }
            gameObject.SetActive(false); 
        }
    }

    IEnumerator BoostSpeed(MovementPlayer player)
    {
        player.Ms *= boostAmount; 
        yield return new WaitForSeconds(boostDuration); 


        if (player.gameObject.activeSelf) 
        {
            player.Ms /= boostAmount; 
        }

        Destroy(gameObject); 
    }



}

