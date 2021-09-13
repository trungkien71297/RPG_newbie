using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 100f;

        bool isDead = false;
        public bool IsDead()
        {
            return isDead;
        }

        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health - damage, 0);
            if (health == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (isDead) return;
            GetComponent<Animator>().SetTrigger("die");
            isDead = true;
        }
    }
}