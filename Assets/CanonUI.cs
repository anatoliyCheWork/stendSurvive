using UnityEngine.UI;
using UnityEngine;

public class CanonUI : MonoBehaviour
{
    [SerializeField] private Image _targetImage;
    [SerializeField] private Canon _targetCanon;
    void Start()
    {
        _targetImage.fillAmount = 0;
    }


    void Update()
    {
        _targetImage.fillAmount = _targetCanon.TemperatureCanan;
    }
}
