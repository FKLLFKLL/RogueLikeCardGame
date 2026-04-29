using UnityEngine;

namespace AshRoad.Data
{
    [CreateAssetMenu(menuName = "AshRoad/ClueData")]
    public class ClueData : ScriptableObject
    {
        public string id;
        public string groupId;
        public string title;
        [TextArea] public string description;
    }
}
