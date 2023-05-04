using UnityEngine;

public class RespawnGem : MonoBehaviour
{
    public Transform plankTransform;
    private void Start()
    {
        respawn();
    }
    static float NextRandom(float min, float max)
    {
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }

    public void respawn()
    {
        Vector3 gemPos = transform.position;
        Vector3 plankPos = plankTransform.position;
        gemPos.z = NextRandom(plankPos.z-2.5f,plankPos.z+2.5f);
        gemPos.x = NextRandom(plankPos.x-2.5f,plankPos.x+2.5f);

        transform.position = gemPos;
    }
}
