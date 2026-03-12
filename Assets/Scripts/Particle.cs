using UnityEngine;

public class Particle : MonoBehaviour
{
    //Otras
    public Vector2 ini;

    //Variables
    public float vo;
    public Vector2 vel0;
    private float ao;
    public float lifespan;
    public float life = 0f;
    private float grav;

    public void Iniciar(float vo, float ao, float lifespan, float grav)
    {
        this.ini = new Vector2(transform.position.x, transform.position.y);

        this.vo = vo;
        this.ao = ao;
        this.vel0 = new Vector2(vo * Mathf.Cos(ao), vo * Mathf.Sin(ao));

        this.lifespan = lifespan;
        this.grav = grav;
    }

    private void Update()
    {
        life += Time.deltaTime;
    }
}
