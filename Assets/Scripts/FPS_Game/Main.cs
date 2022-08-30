using FPS_Game.UI;
using UnityEngine;

namespace FPS_Game
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Interactable[] interactItems;

        private PlayerInput inputSystem;

        private MoveController _moveController;
        private LookController _lookController;

        private ListExecuteController _executeUpdate;
        private ListExecuteController _executeLateUpdate;

        /*UI components*/
        private BonusBarManager _bonusBarManager;
        private HealthBarManager _healthBarManager;

        private void Awake()
        {
            inputSystem = new PlayerInput();
            _executeUpdate = new ListExecuteController();
            _executeLateUpdate = new ListExecuteController();

            _moveController = new MoveController(inputSystem, _player);
            _executeUpdate.AddExecuteObject(_moveController);

            _lookController = new LookController(inputSystem, _player);
            _executeLateUpdate.AddExecuteObject(_lookController);

            _bonusBarManager = GetComponentInChildren<BonusBarManager>();
            _healthBarManager = GetComponentInChildren<HealthBarManager>();

            SpawnBonus();
        }

        private void Update()
        {
            while (_executeUpdate.MoveNext()) 
            {
                IExecute tmp = (IExecute)_executeUpdate.Current;
                tmp.Update();
            }
            _executeUpdate.Reset();
        }

        private void LateUpdate()
        {
            while (_executeLateUpdate.MoveNext())
            {
                IExecute tmp = (IExecute)_executeLateUpdate.Current;
                tmp.Update();
            }
            _executeLateUpdate.Reset();
        }


        private void SpawnBonus()
        {
            for (int i = 0; i < interactItems.Length; i++)
            {
                interactItems[i].gameObject.SetActive(true);
                interactItems[i].IsActive = true;

                if(interactItems[i] is Bonus bonus) 
                {
                    bonus.AddBonus += _player.AddBonus;
                    bonus.AddBonus += _bonusBarManager.AddBonus;
                }
                if(interactItems[i] is AidKit aidKit)
                {
                    aidKit.Heal += _player.Heal;
                }
                if (interactItems[i] is Trap trap)
                {
                    trap.TakeDamage += _player.TakeDamage;
                }
            }
        }
    }
}

