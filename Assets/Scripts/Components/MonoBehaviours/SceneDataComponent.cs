using UnityEngine;
using TMPro;

namespace Components {
    public class SceneDataComponent : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText;
        public HolderView TopItemsHolderContent;
        public HolderView BottomItemsHolderContent;
        public float holdersPushSpeed;
        public bool isPlayButtonAnable;
        public float spaceBetweenItems = 1.8f;
        public float pushPower = 200;
        private int _score = 10;
        public bool isGameActive = false;


        public int Score => _score;
        public void SetScrollSpeed()
        {
            if (isPlayButtonAnable)
            {
                holdersPushSpeed = pushPower;
                //isGameActive = true;
                isPlayButtonAnable = false;
            }
        }
        public void SetScore(int score)
        {
            _score = score;
            scoreText.text = _score.ToString();
        }
    }
}