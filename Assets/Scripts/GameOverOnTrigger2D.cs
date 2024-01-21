using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameOverOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger game over")]
    [SerializeField] string triggeringTag;
    [Tooltip("Amount of hitting to game over")] [SerializeField] int hitPoints = 3;
    private int hitCount = 0;
    [SerializeField] TMP_Text livesText;
    

    private void OnTriggerEnter2D(Collider2D other)
     {
        if (other.tag == triggeringTag && enabled) 
        {
            hitCount++;
            Destroy(other.gameObject);
            UpdateLivesText();
            if (hitCount>=hitPoints) 
            {
               Destroy(this.gameObject);
               Debug.Log("Game over!");
                UnityEngine.SceneManagement.SceneManager.LoadScene(2);
            }

            //Application.Quit();
            // UnityEditor.EditorApplication.isPlaying = false;  # Error on editor 2021.3
        }
    }

    private void UpdateLivesText() 
    {
        livesText.text = $"Lives: {hitPoints - hitCount}";
    }

    private void Update() {
        /* Just to show the enabled checkbox in Editor */
    }

}
