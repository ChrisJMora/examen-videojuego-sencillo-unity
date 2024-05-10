using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Player
{
    public class WinController : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Win"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
