using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PracticaJugador;

namespace PracticaJugadorTests
{
    [TestClass]
    public class JugadorTests
    {
        /// <summary> 1. Verificar asignación de nombre "Ash" </summary>
        [TestMethod]
        public void CrearJugador_NombreAsh_SeAsignaCorrectamente()
        {
            Jugador jugador = new Jugador("Ash");
            Assert.AreEqual("Ash", jugador.Nombre);
        }

        /// <summary> 2. Comprobar incremento de oro </summary>
        [TestMethod]
        public void AnyadirOro_CantidadPositiva_IncrementaCorrectamente()
        {
            Jugador jugador = new Jugador("Ash");
            jugador.AnyadirOro(50);
            Assert.AreEqual(50, jugador.Oro);
        }

        /// <summary> 3. Comprobar reducción de vida </summary>
        [TestMethod]
        public void QuitarVida_CantidadPositiva_ReduceCorrectamente()
        {
            Jugador jugador = new Jugador("Ash");
            jugador.QuitarVida(20);
            Assert.AreEqual(80, jugador.Vida);
        }

        /// <summary> 4. Verificar que inicialmente npc es false </summary>
        [TestMethod]
        public void Jugador_Inicialmente_NpcEsFalse()
        {
            Jugador jugador = new Jugador("Ash");
            Assert.IsFalse(jugador.EsNpc());
        }

        /// <summary> 5. Comprobar asignarNPC() a true </summary>
        [TestMethod]
        public void AsignarNPC_CambiaAtributoATrue()
        {
            Jugador jugador = new Jugador("Ash");
            jugador.AsignarNPC();
            Assert.IsTrue(jugador.EsNpc());
        }

        /// <summary> 6. Comprobar asignar y luego desasignar NPC </summary>
        [TestMethod]
        public void DesasignarNPC_TrasAsignar_VuelveAFalse()
        {
            Jugador jugador = new Jugador("Ash");
            jugador.AsignarNPC();
            jugador.DesasignarNPC();
            Assert.IsFalse(jugador.EsNpc());
        }

        /// <summary> 7. Excepción al quitar más oro del disponible </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void QuitarOro_MasDelDisponible_LanzaExcepcion()
        {
            Jugador jugador = new Jugador("Ash");
            // Nota: El método QuitarOro debe validar esto en la clase Jugador
            jugador.QuitarOro(100);
        }

        /// <summary> 8. Excepción al quitar resistencia no posible </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void QuitarResistencia_CuandoEsCero_LanzaExcepcion()
        {
            Jugador jugador = new Jugador("Ash");
            for (int i = 0; i < 5; i++) jugador.QuitarResistencia();
            jugador.QuitarResistencia();
        }

        /// <summary> 9. Excepción al intentar cambiar nombre a null </summary>
        /// <remarks> Nota: En C# se usa ArgumentNullException para representar NullPointerException </remarks>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CambiarNombre_A_Null_LanzaExcepcion()
        {
            Jugador jugador = new Jugador("Ash");
            jugador.CambiarNombre(null);
        }

        /// <summary> 10. Excepción al crear jugador con nombre null </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CrearJugador_NombreNull_LanzaExcepcion()
        {
            Jugador jugador = new Jugador(null);
        }

        /// <summary> 11. Excepción si es NPC e intenta añadir resistencia </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AnyadirResistencia_SiEsNpc_LanzaExcepcion()
        {
            Jugador jugador = new Jugador("Ash");
            jugador.AsignarNPC();
            jugador.AnyadirResistencia();
        }
    }
}
