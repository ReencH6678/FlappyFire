using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewerImage : MonoBehaviour
{
    [SerializeField] private List<Sprite> _imageList;
    [SerializeField] private Health _health;

    [SerializeField] private Image _image;

    private void OnEnable()
    {
        _health.Changed += UpdateView;
    }

    private void OnDisable()
    {
        _health.Changed -= UpdateView;
    }

    private void UpdateView(float currentCount, float maxCount)
    {
        float healthPercent = currentCount / maxCount;

        int maxIndex = 4;
        int minIndex = 0;

        int imageIndex = Mathf.Clamp(Mathf.CeilToInt((1 - healthPercent) * _imageList.Count), minIndex, maxIndex);

        _image.sprite = _imageList[imageIndex];
    }
}
