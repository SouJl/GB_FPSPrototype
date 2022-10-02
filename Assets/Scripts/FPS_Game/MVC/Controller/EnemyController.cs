using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class EnemyController: IExecute
    {

        private List<EnemyView> _enemyViews;

        private List<EnemyModel> _enemyModels;

        private Transform _playerTrans;

        public EnemyController(List<EnemyView> views, PlayerModel player)
        {
            if(views != null)
            {
                _enemyViews = views;

                _enemyModels = new List<EnemyModel>();

                foreach (var view in views)
                {
                    _enemyModels.Add(new EnemyModel(view));
                    _enemyModels.Last().DealDamage += player.TakeDamage;
                }

                _playerTrans = player.Transform;
            }
        }

        public void Execute()
        {
            if (_enemyModels == null || !_enemyModels.Any()) return;

            foreach(var enemy in _enemyModels)
            {
                if(enemy.CurrentHealth <= 0)
                {
                    var view = _enemyViews.Find(e => e.name == enemy.Name);
                    view.Agent.enabled = false;
                    view.gameObject.SetActive(false);
                }

                enemy.Move(_playerTrans.position);
            }
        }
    }
}
