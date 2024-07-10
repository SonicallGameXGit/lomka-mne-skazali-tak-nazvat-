using System;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    [SerializeField] private GameObject diePanel;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip exxBlea; 
    public Action OnDie;

    private void OnEnable()
    {
        OnDie += Die; 
    }

    private void OnDisable()
    {
        OnDie -= Die;
    }

    private void Die()
    {
        diePanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
