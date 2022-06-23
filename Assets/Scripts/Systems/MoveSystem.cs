using Components;
using Data;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems
{
    public class MoveSystem : IEcsRunSystem
    {
        private SceneDataComponent sceneData;
        private StaticData _staticData;
        EcsFilter<HolderComponent, ActiveHolder> holdersFilter;
        public void Run()
        {
            var currectSpeed = _staticData.holdersFaidingSpeed * Time.deltaTime;
            foreach (var i in holdersFilter)
            {
                ref HolderComponent holderComponent = ref holdersFilter.Get1(i);
                
                for (int j = 0; j < holderComponent.items.Count; j++)
                {
                    //перемещаем итем
                    var item =  holderComponent.items[j];
                    item.transform.Translate(item.direction * holderComponent.currentSpeed * Time.deltaTime, Space.World);

                    var socketX = holderComponent.stopPosition.transform.position.x;
                    holderComponent.isSocketFull = item.transform.position.x >= socketX - 10 &&
                        item.transform.position.x <= socketX + 10;
                    //удаляем за пределами
                    if (item.direction == Vector3.left && item.transform.position.x < 0 ||
                    item.direction == Vector3.right && item.transform.position.x > Camera.main.pixelWidth)
                    {
                        holderComponent.items.Remove(item);
                        DestroyEntity(item);
                    }
                    //замедляем движение
                    if (holderComponent.currentSpeed > _staticData.holdersMinSpeed)
                    {
                        holderComponent.currentSpeed -= currectSpeed;
                    }
                    //если достиг мин. скорости, довести до позиции итемы
                    else if (holderComponent.isSocketFull) 
                    {
                        holderComponent.currentSpeed = 0;
                        ref EcsEntity entity = ref holdersFilter.GetEntity(i);
                        entity.Get<ReadyToCount>();
                        entity.Del<ActiveHolder>();
                    }
                }
            }
        }
        private void DestroyEntity(ItemMovableComponent movableComponent)
        {
            GameObject.Destroy(movableComponent.transform.gameObject);
            movableComponent.entity.Destroy();
        }

    }
}