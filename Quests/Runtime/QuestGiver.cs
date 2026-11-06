using Dungeon.Core.Input;
using Dungeon.Gameplay.Interaction;
using Dungeon.Visual.UI.Quests;
using UnityEngine;

namespace Dungeon.Gameplay.Quests {

    public sealed class QuestGiver : Interactable
    {
        [SerializeField] private QuestDefinition _quest;
        [SerializeField] private NpcProfile _profile;

        public override string PromptText =>
            _profile != null ? $"Talk to {_profile.DisplayName}" : "Talk";

        public override bool CanInteract(Transform interactor) =>
            base.CanInteract(interactor) && _quest != null;

        public override void Interact(Transform interactor)
        {
            if (interactor == null || !CanInteract(interactor))
            {
                return;
            }

            var input = interactor.GetComponent<PlayerInputController>();
            var window = FindAnyObjectByType<QuestWindowUI>();
            if (input == null || window == null)
            {
                return;
            }

            window.ShowQuestWindow(_quest, _profile, input);
        }
    }

}