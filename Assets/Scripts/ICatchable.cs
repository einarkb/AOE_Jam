using UnityEngine;

public interface ICatchable
{
    void Catch();
    void Release(Vector2 parentVelocity);
}
