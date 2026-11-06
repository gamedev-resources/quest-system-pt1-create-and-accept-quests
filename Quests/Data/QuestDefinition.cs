using System;
using System.Collections.Generic;
using Dungeon.Config.Items;
using UnityEngine;

namespace Dungeon.Gameplay.Quests
{
    [CreateAssetMenu(fileName = "NewQuest", menuName = "Quests/Quest Definition")]
    public sealed class QuestDefinition : ScriptableObject
    {
        public string Id = Guid.NewGuid().ToString();
        public string Title;
        
        [TextArea] 
        public string Description;
        
        [SerializeReference, SubclassSelector]
        public List<ObjectiveDefinition> Objectives = new();
        [SerializeReference, SubclassSelector]
        public List<RewardDefinition> Rewards = new();
    }
    
}


