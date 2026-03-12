using NUnit.Framework;
using UnityEngine;
using System;
using System.Collections.Generic;

public class ParticlesController : MonoBehaviour
{
    [SerializeField] private int amount;
    [SerializeField] private float vo;
    [SerializeField] private float ao;
    [SerializeField] private float lifespan;
    [SerializeField] private float grav;

    [SerializeField] private GameObject particle;
    private List<GameObject> particles = new List<GameObject>();

    void Update()
    {
        //Input para generar explosiones de partículas
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateParticleExplotion(amount);
        }

        //Eliminar referencias nulas de la lista
        particles.RemoveAll(p => p == null);

        //Actualizar posición partículas
        if (particles.Count > 0)
        {
            foreach (GameObject par in particles)
            {
                var script = par.GetComponent<Particle>();
                UpdateParticlePosition(script, script.life);
            }
        }
    }

    void CreateParticleExplotion(int a)
    {
        for(int i = 0; i < a; i++)
        {
            var part = Instantiate(particle);
            part.GetComponent<Particle>().Iniciar(RandomizeValue(vo, 0.5f), UnityEngine.Random.Range(0, 359), RandomizeValue(lifespan, 0.5f), grav);
            particles.Add(part);
        }
    }

    void UpdateParticlePosition(Particle p, float time)
    {
        //Actualizar posición
        p.transform.position += new Vector3(p.ini.x + p.vel0.x * time, p.ini.y + p.vel0.y * time - (grav * time * time) / 2, 0);

        //Destruir gameobject en caso de que el tiempo que lleva activa sea mayor a su vida máxima
        if (p.life > p.lifespan)
        {
            Destroy(p.gameObject);
        }
    }

    private float RandomizeValue(float value, float ratio)
    {
        return UnityEngine.Random.Range(-value * ratio, value * ratio) + value;
    }
}
