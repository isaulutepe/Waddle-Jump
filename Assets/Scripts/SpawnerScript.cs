using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    public float createTime;
    public float upForceLeft;
    public float upForceRight;
    [SerializeField] float deleteTime;

    Vector3 spawner1Position = new Vector3(-2.86f, -11.17f, 0f);
    Vector3 spawner2Position = new Vector3(2.86f, -11.17f, 0f);


    private void Start()
    {
        StartCoroutine(DelayForAnimation());
    }

    IEnumerator CreateObsticle()
    {
        while (true)
        {
            int randomIndex1 = Random.Range(0, objects.Length);
            int randomIndex2 = Random.Range(0, objects.Length);
            GameObject newObsticleLeft = Instantiate(objects[randomIndex1], spawner1Position, Quaternion.identity);
            GameObject newObsticleRight = Instantiate(objects[randomIndex2], spawner2Position, Quaternion.identity);
            Rigidbody2D rbObsticleLeft = newObsticleLeft.GetComponent<Rigidbody2D>();
            Rigidbody2D rbObsticleRight = newObsticleRight.GetComponent<Rigidbody2D>();
            if (rbObsticleLeft != null && rbObsticleRight != null)
            {
                rbObsticleLeft.AddForce(Vector2.up * upForceLeft, ForceMode2D.Impulse);
                rbObsticleRight.AddForce(Vector2.up * upForceRight, ForceMode2D.Impulse);
            }
            Destroy(newObsticleLeft, deleteTime);
            Destroy(newObsticleRight, deleteTime);
            yield return new WaitForSeconds(createTime);

        }
    }
    IEnumerator DelayForAnimation()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(CreateObsticle());
    }
}
