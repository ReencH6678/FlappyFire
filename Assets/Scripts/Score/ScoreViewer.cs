using TMPro;
using UnityEngine;

[RequireComponent(typeof(Score))]
public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private Score _score;

    private void Awake()
    {
        _score = GetComponent<Score>();
    }

    private void OnEnable()
    {
        _score.Changed += UpdateScore;
    }

    private void OnDisable()
    {
        _score.Changed -= UpdateScore;
    }

    private void UpdateScore(int count)
    {
        _text.text = count.ToString();  
    }
}
