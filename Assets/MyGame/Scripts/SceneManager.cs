using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Nutze TextMeshPro – falls nicht, ersetze durch UnityEngine.UI

public class ScoreManager : MonoBehaviour
{
    // Der aktuelle Score
    public int score = 0;

    // Referenzen zu den UI-Elementen:
    public TextMeshProUGUI scoreText;    // Anzeige des Scores
    public Button clickButton;           // Button, der den Score erhöht
    public Button saveButton;            // Button zum Speichern
    public Button loadButton;            // Button zum Laden

    void Start()
    { 

        UpdateScoreText();

        // Falls du die Button-Listeners nicht im Inspector setzt, kannst du sie hier programmatisch anhängen:
        if (clickButton != null)
            clickButton.onClick.AddListener(AddPoint);
        if (saveButton != null)
            saveButton.onClick.AddListener(SaveScore);
        if (loadButton != null)
            loadButton.onClick.AddListener(LoadScore);
    }

    // Diese Methode wird beim Klick auf den "Klick"-Button aufgerufen
    public void AddPoint()
    {
        if(score > 10)
        {
            score *= 2;
            UpdateScoreText();
            Debug.Log("Klick! Neuer Score: " + score);
        } 
        
        if(score > 1000)
        {
            score = 0;
            UpdateScoreText();
            Debug.Log("Klick! Neuer Score: " + score);
        }

        else
        {
            score++;
            UpdateScoreText();
            Debug.Log("Klick! Neuer Score: " + score);
        }
        
    }

    // Speichert den aktuellen Score mithilfe von PlayerPrefs
    public void SaveScore()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save(); // Erzwingt das Speichern, ist optional
        Debug.Log("Score gespeichert: " + score);
    }

    // Lädt den Score und aktualisiert die Anzeige
    public void LoadScore()
    {
        score = PlayerPrefs.GetInt("score", 0);  // Wenn kein Wert gespeichert wurde, wird 0 als Default verwendet
        UpdateScoreText();
        Debug.Log("Score geladen: " + score);
    }

    // Aktualisiert den Text, der den Score anzeigt
    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}
