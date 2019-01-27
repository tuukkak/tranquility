using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player Player;

    void FixedUpdate()
    {
        float z = Player.Movement.InputZ * Time.fixedDeltaTime * Player.Hero.Speed;
        float x = Player.Movement.InputX * Time.fixedDeltaTime * Player.Hero.Speed;
        transform.Translate(Vector3.ClampMagnitude(new Vector3(x, 0, z), Time.fixedDeltaTime * Player.Hero.Speed));

        transform.rotation = Quaternion.Euler(0, Player.Movement.Rotation, 0);

        Player.Movement.CordX = transform.position.x;
        Player.Movement.CordZ = transform.position.z;
    }
}
