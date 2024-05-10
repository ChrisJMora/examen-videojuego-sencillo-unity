using UnityEngine;

namespace Scripts.Stars
{    
    public class SpawnRocksController : MonoBehaviour 
    {
        public GameObject rockPrefab; // Prefab de la estrella
        public float tiempoEspera = 1f; // Tiempo de espera para la generación de estrellas
        void Start ()
        {
            // Instancia una roca en una posición aleatoria cierto tiempo de espera
            InvokeRepeating(nameof(InstantiateRandomStar), tiempoEspera, tiempoEspera);
        }

        void Update ()
        {
            float size = Random.Range(0.5f, 2f);
            // Escala de la roca
            rockPrefab.transform.localScale = new Vector3(size, size, size);
        }

        private void InstantiateRandomStar()
        {
            // Genera una posición aleatoria
            Vector3 posicion = new(Random.Range(0f, 40f), 10f, 0f);
            // Instancia la roca
            Instantiate(rockPrefab, posicion, Quaternion.identity);
        }
    }
}