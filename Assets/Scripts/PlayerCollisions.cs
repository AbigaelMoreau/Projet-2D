using UnityEngine;
using UnityEngine.SceneManagement;

    public class PlayerCollisions : MonoBehaviour
    {
        public int life = 3;
        public int cherries = 0;
        public int melons = 0;
        public int bananas = 0;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Spike"))
            {
                TakeDamages(3);
            }
            
            if (collision.CompareTag("SpikeHead"))
            {
                TakeDamages(3);
            }

            if (collision.CompareTag("Cherry"))
            {
                cherries++;
                Destroy(collision.gameObject);
            }
            
            if (collision.CompareTag("Melon"))
            {
                melons++;
                Destroy(collision.gameObject);
            }
            
            if (collision.CompareTag("Banana"))
            {
                bananas++;
                Destroy(collision.gameObject);
            }

			if (collision.CompareTag("EndLevel"))
            {
                if(PlayerPrefs.GetInt("MobDestroyed", 0) == 4)
				{
					print("Bravo !");
				}
				else
				{
					print("Il faut detruire le monstre !");
				}

          	 }

        }

        public void TakeDamages(int damage)
        {
            life -= damage;

            Die();
        }

        public void Die()
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 90);
            GetComponent<Collider2D>().isTrigger = true;
            Invoke("RestartLevel", 1);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
            
    }
