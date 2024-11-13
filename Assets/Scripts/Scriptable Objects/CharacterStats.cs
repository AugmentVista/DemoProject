using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="CharacterStats", menuName = "Character/CharacterStats")]
public class CharacterStats : ScriptableObject
{
    public string characterName;

    public void ShowName()
    {
        Debug.Log($"Character Name is: {characterName}");
    }
}
