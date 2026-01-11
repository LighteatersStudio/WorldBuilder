using UnityEngine;

namespace BusinessLogic.WorldBuilder.Support
{
    public class RemoveOnStart : MonoBehaviour
    {
        protected void Start()
        {
            Destroy(gameObject);
        }
    }
}