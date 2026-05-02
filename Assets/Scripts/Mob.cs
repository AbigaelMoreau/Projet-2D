using UnityEngine;

public class Mob : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Contact !");
            PlayerPrefs.SetInt("MobDestroyed", 4);
            Destroy(gameObject);
           
        }    
    }
}
