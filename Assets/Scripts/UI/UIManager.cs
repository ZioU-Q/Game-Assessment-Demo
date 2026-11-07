using System;
using UnityEngine;

public class UIManager:MonoBehaviour
{
    public PlayerStartBar playerStartBar;
    [Header("¼àÌýÊÂ¼þ")]
    public CharacterEventSO healthEvent;

    private void OnEnable()
    {
        healthEvent.OnEventRaised += OnHealthEvent;
    }
    private void OnDisable()
    {
        healthEvent.OnEventRaised -= OnHealthEvent;
    }

    private void OnHealthEvent(Character character)
    {
       var persentage=character.currentHealth/character.maxHealth;
        playerStartBar.OnHealthChange(persentage);
    }
}
