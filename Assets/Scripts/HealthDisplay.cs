using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{

    TextMeshProUGUI myText;
    Player player;
    // Start is called before the first frame update
    void Awake()
    {
        myText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = player.GetCurrentHP().ToString();
    }
}
