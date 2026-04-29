using System.Collections.Generic;
using UnityEngine;

namespace AshRoad.Data
{
    [CreateAssetMenu(menuName = "AshRoad/EventData")]
    public class EventData : ScriptableObject
    {
        public string id;
        public string title;
        [TextArea] public string body;
        public List<EventChoiceData> choices = new();
    }
}
