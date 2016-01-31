using UnityEngine;

public interface IProjectile
{
    void initialize(float x, float z, Quaternion nheading, BulletPool pool, Team.TeamEnum alignment);
    GameObject getGameObject();
}