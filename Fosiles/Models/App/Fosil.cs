using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fosiles.Models.App
{
    public class Fosil
    {
        private string muestra;
        private string nombre;
        private Eon eon;
        private string comentario;

        private Fosil(FosilBuilder builder)
        {
            this.muestra = builder.muestra;
        }

        /// <summary>
        /// Builder de la clase Fosil.
        /// </summary>
        internal class FosilBuilder
        {
            public string muestra;
            public string nombre;
            public Eon eon;
            public string comentario;
            public Estado estado:

            public FosilBuilder(string muestra, Eon eon)
            {
                
            }

            public Fosil build()
            {
                return new Fosil(this);
            }

            public FosilBuilder setNombre(string nombre)
            {
                this.nombre = nombre;
                return this;
            }

            public FosilBuilder setComentario(string comentario)
            {
                this.comentario = comentario;
                return this;
            }

            
        }
    }
}
