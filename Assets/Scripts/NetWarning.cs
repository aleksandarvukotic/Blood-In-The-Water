using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetWarning : MonoBehaviour
{
    [SerializeField] GameObject netWarning;
    [SerializeField] GameObject netPrefab;
    [SerializeField] float netSpeed;
    [SerializeField] float netSpawnInterval;
    float warningDuration = 1f;
    Vector3 netDestination;
    GameObject net;
    GameObject netWarningInstance;
    GameObject netInstance;

    BoxCollider2D boxCollider;
    Animator anim;

    void Start()
    {
        //boxCollider = GetComponent<BoxCollider2D>();
        StartCoroutine(SpawnNet());
    }

    private void Update()
    {
        if (net != null && net.transform.position == netDestination)
        {
            Destroy(net);
        }
    }

    private void LaunchNet()
    {
        float randomX = Random.Range(-0.7f, 1.4f);
        float randomY = Random.Range(-0.6f, 0.6f);
        Vector3 netDestination = new Vector3(randomX, randomY, 0);

        netWarningInstance = Instantiate(netWarning, netDestination, Quaternion.identity);
        Destroy(netWarningInstance, warningDuration);

        netInstance = Instantiate(netPrefab, transform.position, Quaternion.identity);

        StartCoroutine(MoveNet());

        /*
        GameObject redDot = Instantiate(netWarning, netDestination, transform.rotation);
        Destroy(redDot, warningDuration);

        anim = redDot.GetComponent<Animator>();
        anim.SetTrigger("Fire");

        net = Instantiate(netPrefab, transform.position, Quaternion.identity);
        StartCoroutine(MoveNet());
        */
    }

    private IEnumerator MoveNet()
    {
        Vector3 direction = (netDestination - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, netDestination);
        float travelTime = distance / netSpeed;
        float elapsedTime = 0f;

        while (elapsedTime < travelTime)
        {
            elapsedTime += Time.deltaTime;
            netInstance.transform.position += direction * (netSpeed * Time.deltaTime);
            yield return null;
            /*
            elapsedTime += Time.deltaTime;
            net.transform.position += direction * (netSpeed * Time.deltaTime);
            yield return null;
            */
        }

        Destroy(net);
    }
    private IEnumerator SpawnNet()
    {
        while (true)
        {
            yield return new WaitForSeconds(netSpawnInterval);
            LaunchNet();
        }
    }

}
