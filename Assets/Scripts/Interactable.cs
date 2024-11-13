using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public PickupItem Coin;
    int value;

    public enum InteractionType
    { 
        Door,
        Button,
        Pickup
    }

    public InteractionType type;

    public void Activate()
    {
        Debug.Log("Door");
    }

    public int PickUpItem()
    {
        int value = Coin.Value;
        return value;
    }
}
