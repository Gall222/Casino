using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Components
{
    public class Swicher : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] Image switcherImage;
        [SerializeField] Image switcher;

        private bool _isOn = false;
        public bool IsOn => _isOn;


        public void OnPointerDown(PointerEventData eventData)
        {
            _isOn = !_isOn;
            switcherImage.color = _isOn ? Color.green : Color.white;
            var newSwitcherPosition = _isOn ?
                new Vector2(switcherImage.rectTransform.rect.width / 4, 0) :
                new Vector2();
            switcher.transform.localPosition = newSwitcherPosition;
            print(_isOn);
        }
    }
}