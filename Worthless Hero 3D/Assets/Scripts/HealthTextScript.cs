using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthTextScript : MonoBehaviour
{
    public GameObject playerObject;
    public PlayerScript player;
    public TextMeshPro healthText;


    private void Awake()
    {
        player = playerObject.GetComponent<PlayerScript>();
        healthText = gameObject.GetComponent<TextMeshPro>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = player.health.ToString() + "/" + player.maxHealth.ToString();
    }
}
