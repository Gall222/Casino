using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Data
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        public List<Sprite> itemsList;
        public float holdersMoveSpeed;
        public float holdersFaidingSpeed;
        public float holdersMinSpeed;
        public int itemsCountInHolder;
        public Image itemPrefab;
    }

}