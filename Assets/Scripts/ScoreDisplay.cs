using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{

    TextMeshProUGUI myText;
    void Awake()
    {
        myText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        myText.text = GameSession.GetScore().ToString();
    }
}
