using UnityEngine;
using RPG.Movement;
using UnityEngine.AI;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 10f;        
        Transform target;

        private void Update()
        {
            if(target == null) return;

            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttckBehaviour();
            }

            
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        private void AttckBehaviour()
            {
                GetComponent<Animator>().SetTrigger("attack");
            }

        public void Attack(CombatTarget target)
        {
            Debug.Log("Bunch");
            GetComponent<ActionSchedule>().StartAction(this);
            this.target = target.transform;
        }

        public void Cancel()
        {
            target = null;
        }

        void Hit() 
        {

        }
    }
}