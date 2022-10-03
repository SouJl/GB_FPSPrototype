using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class EnemyController: IExecute
    {

        private List<BaseEnemyView> _enemyViews;

        private List<AbstractEnemyModel> _enemyModels;

        private Transform _playerTrans;

        public EnemyController(List<BaseEnemyView> views, PlayerModel player)
        {
            if(views != null)
            {
                _enemyViews = views;

                _enemyModels = new List<AbstractEnemyModel>();

                foreach (var view in views)
                {
                    AbstractEnemyModel enemy = null;

                    if(view is BomberEnemyView bomberView)
                    {
                        enemy = new BomberEnemyModel(bomberView);
                        enemy.DealDamage += player.TakeDamage;
                    } 

                    if(enemy != null)
                        _enemyModels.Add(enemy);
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
