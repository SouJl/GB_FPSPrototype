using UnityEngine;

namespace FPS_Game 
{

    public interface IInteract 
    {
        public bool IsActive { get; set; }

        void Interaction(Player player) { }
    }
}

