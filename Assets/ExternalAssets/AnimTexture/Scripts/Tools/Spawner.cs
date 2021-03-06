namespace AnimTexture
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Spawner : MonoBehaviour
    {
        public GameObject[] prefabs;
        public int count = 500;
        public float radius = 10;
        public float y = 20;

        public float animSampleRate = 30f;
        public float startTime = 0;

        public bool spawn;
        public Transform root;
        // Start is called before the first frame update
        void Start()
        {
            if (!root)
                root = transform;
        }

        // Update is called once per frame
        void Update()
        {
            if (spawn)
            {
                spawn = false;

                StartCoroutine(WaitForSpawn());
            }
        }

        IEnumerator WaitForSpawn()
        {
            for (int i = 0; i < count; i++)
            {
                var p = Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform);

                var pos = Random.insideUnitSphere * radius;
                pos.y = Random.Range(-y, y);
                p.transform.parent = root;
                p.transform.localPosition = pos;

                yield return 0;
            }
        }
    }
}