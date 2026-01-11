using UnityEngine;
using Zenject;

namespace BusinessLogic.WorldBuilder.EntityNode
{
    public class EntityFactory<TEntity>: PlaceholderFactory<GameObject, Transform, TEntity>
    {
    }
    
    public class EntityFactory<TEntity, TContext>: PlaceholderFactory<GameObject, Transform, TContext, TEntity>
    {
    }
}