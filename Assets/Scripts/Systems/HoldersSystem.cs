using Components;
using Data;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class HoldersSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private SceneDataComponent sceneData;
        private StaticData _staticData;

        EcsFilter<HolderComponent> holderssFilter;

        public void Run()
        {
            foreach (var i in holderssFilter)
            {
                ref HolderComponent holderComponent = ref holderssFilter.Get1(i);
                if (holderComponent.items.Count < _staticData.itemsCountInHolder)
                {
                    CreateNewItem(ref holderComponent);
                }
            }
            PushItems();
        }

        private void CreateNewItem(ref HolderComponent holderComponent)
        {
            int randomIconsInt = Random.Range(0, _staticData.itemsList.Count);

            var newItem = _world.NewEntity();
            ref ItemMovableComponent movableComponent = ref newItem.Get<ItemMovableComponent>();
            var spawnedItem = GameObject.Instantiate(_staticData.itemPrefab, holderComponent.content.transform.position, Quaternion.identity.normalized);
            spawnedItem.sprite = _staticData.itemsList[randomIconsInt];
            spawnedItem.transform.SetParent(holderComponent.content.transform);
            movableComponent.itemName = spawnedItem.sprite.name;
            movableComponent.transform = spawnedItem.transform;
            movableComponent.direction = holderComponent.direction;
            movableComponent.holder = holderComponent;
            movableComponent.entity = newItem;
            if (holderComponent.items.Count > 0)
            {
                if (holderComponent.direction == Vector3.left)
                {
                    spawnedItem.transform.position = new Vector2(
                holderComponent.items[holderComponent.items.Count - 1].transform.position.x +
                (spawnedItem.rectTransform.rect.width * spawnedItem.transform.localScale.x * sceneData.spaceBetweenItems)
                , spawnedItem.transform.position.y);
                }
                else
                {
                    spawnedItem.transform.position = new Vector2(
                holderComponent.items[holderComponent.items.Count - 1].transform.position.x -
                (spawnedItem.rectTransform.rect.width * spawnedItem.transform.localScale.x * sceneData.spaceBetweenItems)
                , spawnedItem.transform.position.y);
                }
                
            }
            holderComponent.items.Add(movableComponent);

        }
        private void PushItems()
        {
            if (sceneData.holdersPushSpeed == 0) { return; }
            foreach (var i in holderssFilter)
            {
                ref HolderComponent holderComponent = ref holderssFilter.Get1(i);
                holderComponent.currentSpeed = sceneData.holdersPushSpeed;
                ref EcsEntity holderEntity = ref holderssFilter.GetEntity(i);
                ref ActiveHolder activeHolder = ref holderEntity.Get<ActiveHolder>();
            }
            sceneData.holdersPushSpeed = 0;
            sceneData.isPlayButtonAnable = false;
        }
    }
}