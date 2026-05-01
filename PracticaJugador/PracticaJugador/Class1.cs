using System;

namespace PracticaJugador
{
    /// <summary>
    /// Clase Jugador: Implementa la lógica de negocio para la gestión de personajes.
    /// Se han aplicado normas de estilo PascalCase para métodos y camelCase para atributos.
    /// </summary>
    public class Jugador
    {
        private string nombre;
        private int vida;
        private double oro;
        private bool esNpc;
        private int resistencia;

        /// <summary>
        /// Constructor: Inicializa un jugador con valores por defecto.
        /// Valida que el nombre no sea nulo (Punto 10 de los tests).
        /// </summary>
        public Jugador(string nombre)
        {
            if (nombre == null) throw new ArgumentNullException(nameof(nombre));

            this.nombre = nombre;
            this.vida = 100;
            this.oro = 0;
            this.esNpc = false;
            this.resistencia = 50;
        }

        // Propiedades públicas para que los tests puedan leer los valores
        public string Nombre => nombre;
        public int Vida => vida;
        public double Oro => oro; // Añadido para solucionar error CS1061

        public void AnyadirOro(int cantidad) => oro += cantidad;

        /// <summary>
        /// Reduce el oro del jugador. 
        /// Lanza ArgumentOutOfRangeException si se intenta quitar más del disponible (Punto 7).
        /// </summary>
        public void QuitarOro(int cantidad)
        {
            if (cantidad > oro) throw new ArgumentOutOfRangeException(nameof(cantidad), "No hay suficiente oro.");
            oro -= cantidad;
        }

        public void QuitarVida(int cantidad) => vida -= cantidad;

        public void AsignarNPC() => esNpc = true;

        public void DesasignarNPC() => esNpc = false; // Añadido para solucionar error CS1061

        public bool EsNpc() => esNpc;

        /// <summary>
        /// Cambia el nombre del jugador. 
        /// Lanza ArgumentNullException si el nuevo nombre es null (Punto 9).
        /// </summary>
        public void CambiarNombre(string nuevoNombre)
        {
            if (nuevoNombre == null) throw new ArgumentNullException(nameof(nuevoNombre));
            this.nombre = nuevoNombre;
        }

        public void AnyadirResistencia()
        {
            if (esNpc) throw new Exception("Restricción: Los NPC no gestionan resistencia.");
            resistencia += 10;
        }

        /// <summary>
        /// Reduce la resistencia. Lanza ArgumentOutOfRangeException si no es posible (Punto 8).
        /// </summary>
        public void QuitarResistencia()
        {
            if (resistencia <= 0) throw new ArgumentOutOfRangeException(nameof(resistencia), "Resistencia insuficiente.");
            resistencia -= 10;
        }
    }
}