using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controller : MonoBehaviour
{
    public Slider chargeSlider;
    float charge;
    public float maxCharge = 1;
    Vector2 direction;

    public static int score;

    public TextMeshProUGUI scoreText;

    public static FootballGuy selectedPlayer { get; private set; }
    public static void SetSelectedPlayer(FootballGuy player)
    {
        if(selectedPlayer != null)
        {
            selectedPlayer.selected(false);
        }
        selectedPlayer = player;
        selectedPlayer.selected(true);
    }

    private void Update()
    {
        scoreText.text = "Score: " + score;
        if (selectedPlayer == null) return;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            charge = 0;
            direction = Vector2.zero;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            charge += Time.deltaTime;
            charge = Mathf.Clamp(charge, 0, maxCharge);
            chargeSlider.value = charge;

        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)selectedPlayer.transform.position).normalized * charge;
        }
    }

    private void FixedUpdate()
    {
        if(direction != Vector2.zero)
        {
            selectedPlayer.move(direction);
            direction = Vector2.zero;
            charge = 0;
            chargeSlider.value = charge;
        }
    }
}
