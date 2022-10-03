using UnityEngine;

namespace FPS_Game.MVC
{
    enum MoveState
    {
        None,
        ToTarget,
        ToStart,
    }

    public class BomberEnemyModel : AbstractEnemyModel
    {
        /*explosion settings*/
        private float _explosionDealy;

        /*POV*/
        private Transform _pointofView;
        private float _distance;
        private float _angle;
        private LayerMask _targetMask;
        private LayerMask _obstructionMask;


        public Transform PointofView { get => _pointofView; set => _pointofView = value; }
        public float Distance { get => _distance; set => _distance = value; }
        public float Angle { get => _angle; set => _angle = value; }
        public LayerMask TargetMask { get => _targetMask; set => _targetMask = value; }
        public LayerMask ObstructionMask { get => _obstructionMask; set => _obstructionMask = value; }
        public float ExplosionDealy { get => _explosionDealy; set => _explosionDealy = value; }
        
        private float _timeDelay;


        public BomberEnemyModel(BomberEnemyView view) : base(view)
        {
            PointofView = view.FieldOfView.PointofView;
            Distance = view.FieldOfView.Distance;
            Angle = view.FieldOfView.Angle;
            TargetMask = view.FieldOfView.TargetMask;
            ObstructionMask = view.FieldOfView.ObstructionMask;

            ExplosionDealy = view.ExplosionDelay;
        }


        protected override void HowToMove(Vector3 input) 
        {
            switch (CurrentState(input))
            {
                case MoveState.None:
                    {
                        Agent.ResetPath();

                        if (Quaternion.Angle(Transform.rotation, StartTotation) > 0)
                            Transform.rotation = Quaternion.RotateTowards(Transform.rotation, StartTotation, 2f);
                        else
                            LegsAnimator.SetBool("IsMove", false);
                        break;
                    }
                case MoveState.ToTarget:
                    {
                        Agent.SetDestination(input);
                        Transform.LookAt(input);

                        LegsAnimator.SetBool("IsMove", true);

                        break;
                    }
                case MoveState.ToStart:
                    {
                        Agent.SetDestination(StartPosition);
                        LegsAnimator.SetBool("IsMove", true);
                        break;
                    }
            }

        }

        protected override void HowToAttack()
        {
            if (OnExplodeCheck())
            {
                if (_timeDelay > ExplosionDealy)
                {
                    BodyAnimator.SetBool("ExpTrigger", false);
                    DealDamage?.Invoke(50);
                    _timeDelay = 0;

                    IsActive = false;
                }
                else
                {
                    if(!BodyAnimator.GetAnimatorTransitionInfo(0).IsName("ExpTrigger"))
                        BodyAnimator.SetBool("ExpTrigger", true);

                    _timeDelay += Time.deltaTime;
                }          
            }
            else
            {
                BodyAnimator.SetBool("ExpTrigger", false);
                _timeDelay = 0;
            }
        }


        protected override void TakeDamage(float value)
        {
            CurrentHealth -= value;
            if (CurrentHealth <= 0)
            {
                IsActive = false;
                Debug.Log("Enemy Dead");
            }
        }

        public bool OnExplodeCheck()
        {
            var colliders = Physics.OverlapSphere(Transform.position, Distance / 2);
            foreach (var hit in colliders)
            {
                if (!hit.gameObject.CompareTag("Player")) continue;

                return true;
            }

            return false;
        }


        private bool FieldOfViewCheck(Vector3 targetPos)
        {
            if (Vector3.Distance(Transform.position, targetPos) > Distance) return false;
            
            Vector3 directionToTarget = (targetPos - PointofView.position).normalized;

            if (Vector3.Angle(PointofView.forward, directionToTarget) < Angle / 2)
            {
                float distanceToTarget = Vector3.Distance(PointofView.position, targetPos);

                if (!Physics.Raycast(PointofView.position, directionToTarget, distanceToTarget, ObstructionMask))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        private MoveState CurrentState(Vector3 target)
        {
            if (FieldOfViewCheck(target)) return MoveState.ToTarget;
            
            if ((Transform.position -  StartPosition).sqrMagnitude > 0.1f) return MoveState.ToStart;
            
            return MoveState.None;
        }
    }
}


