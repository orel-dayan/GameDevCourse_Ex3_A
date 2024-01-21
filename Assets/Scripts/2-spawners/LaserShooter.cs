using UnityEngine;
using System.Collections;

/**
 * This component spawns the given laser-prefab whenever the player clicks a given key.
 * It also updates the "scoreText" field of the new laser.
 */
public class LaserShooter: ClickSpawner {
    [SerializeField] NumberField scoreField;
    [SerializeField] float timeDelay = 0.5f;
    private bool enableShot = true;

    IEnumerator delay() 
    {
        yield return new WaitForSeconds(timeDelay);
        enableShot = true;
    }

    protected override GameObject spawnObject() 
    {
        if (!enableShot) return null; // don't spawn if we're not enableShot.
        enableShot = false;
        StartCoroutine(delay());
        GameObject newObject = base.spawnObject();  // base = super

        // Modify the text field of the new object.
        ScoreAdder newObjectScoreAdder = newObject.GetComponent<ScoreAdder>();
        if (newObjectScoreAdder)
            newObjectScoreAdder.SetScoreField(scoreField);

        return newObject;
    }
}
