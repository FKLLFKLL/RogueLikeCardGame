using System.IO;
using UnityEngine;
using AshRoad.Models;

namespace AshRoad.Managers
{
    public class SaveManager : MonoBehaviour
    {
        private string SavePath => Path.Combine(Application.persistentDataPath, "ashroad_save.json");
        public void SaveStory(StoryProgressData data) => File.WriteAllText(SavePath, JsonUtility.ToJson(new StorySaveWrapper(data)));
        public StoryProgressData LoadStory()
        {
            if (!File.Exists(SavePath)) return new StoryProgressData();
            var wrapper = JsonUtility.FromJson<StorySaveWrapper>(File.ReadAllText(SavePath));
            return wrapper?.ToData() ?? new StoryProgressData();
        }
        [System.Serializable] private class StorySaveWrapper { public string[] clues; public string[] scenes; public bool trueEndingEligible; public StorySaveWrapper(StoryProgressData d){clues=new System.Collections.Generic.List<string>(d.clues).ToArray(); scenes=new System.Collections.Generic.List<string>(d.scenes).ToArray(); trueEndingEligible=d.trueEndingEligible;} public StoryProgressData ToData(){var d=new StoryProgressData(); if(clues!=null) foreach(var c in clues) d.clues.Add(c); if(scenes!=null) foreach(var s in scenes) d.scenes.Add(s); d.trueEndingEligible=trueEndingEligible; return d;} }
    }
}
