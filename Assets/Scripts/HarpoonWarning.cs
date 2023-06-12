using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonWarning : MonoBehaviour
{
    [SerializeField] GameObject harpoonWarning;
    [SerializeField] GameObject harpoonPrefab;
    [SerializeField] float warningDuration = 1f;
    [SerializeField] float harpoonDestroyOffsetX = 5f;
    [SerializeField] float harpoonSpawnIntervalPhase1 = 4f;
    [SerializeField] float harpoonSpawnIntervalPhase2 = 2f;
    GameObject harpoon;

    private float elapsedTime;
    private Animator anim;

    private void Start()
    {
        StartCoroutine("SpawnHarpoons");
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (harpoon != null && harpoon.transform.position.x >= harpoonDestroyOffsetX)
        {
            Destroy(harpoon);
        }
    }

    private void LaunchHarpoon()
    {
        Vector3 laserDirection = new Vector3(0.75f, Random.Range(-1.1f, 1.1f), 0);
        GameObject laserBeam = Instantiate(harpoonWarning, laserDirection, transform.rotation);
        Destroy(laserBeam, warningDuration);

        anim = laserBeam.GetComponent<Animator>();
        anim.SetTrigger("Fire");

        harpoon = Instantiate(harpoonPrefab, new Vector3(-7f, laserDirection.y, 0), Quaternion.identity);
    }

    private IEnumerator SpawnHarpoons()
    {
        while (true)
        {
            if (elapsedTime <= 30f)
            {
                LaunchHarpoon();
                yield return new WaitForSeconds(harpoonSpawnIntervalPhase1);
            }
            else if (elapsedTime <= 60f)
            {
                LaunchHarpoon();
                yield return new WaitForSeconds(harpoonSpawnIntervalPhase2);
            }
            else if (elapsedTime <= 90f)
            {
                LaunchHarpoon();
                LaunchHarpoon();
                yield return new WaitForSeconds(harpoonSpawnIntervalPhase1);
            }
            else if (elapsedTime <= 120f)
            {
                LaunchHarpoon();
                LaunchHarpoon();
                yield return new WaitForSeconds(harpoonSpawnIntervalPhase2);
            }
            else if (elapsedTime <= 150f)
            {
                LaunchHarpoon();
                LaunchHarpoon();
                LaunchHarpoon();
                yield return new WaitForSeconds(harpoonSpawnIntervalPhase1);
            }
            else if (elapsedTime <= 180f)
            {
                LaunchHarpoon();
                LaunchHarpoon();
                LaunchHarpoon();
                yield return new WaitForSeconds(harpoonSpawnIntervalPhase2);
            }
        }
    }
}