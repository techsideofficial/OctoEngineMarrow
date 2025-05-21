using OctoEngine.MarrowFramework.Base;
using UnityEngine;

namespace OctoEngine.MarrowFramework.Games.TS3Game.Character
{
    public class Townsfolk : MonoBehaviour
    {
        public AudioSystem AudioSystem;
        public Animator Animator;
        public AICharacter AICharacter;

        private void Start()
        {
            AICharacter.StartAI();
            Animator.Play("Walk");
            // TODO: Add smart audio logic.
        }

#if MELONLOADER
        public Townsfolk(IntPtr ptr) : base(ptr) { }
#endif
    }
}
