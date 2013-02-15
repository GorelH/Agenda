using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MonAgendaWPF.Configuration
{
    [Serializable]
    public class WindowConfiguration
    {

        /// <summary>
        /// La largeur de la fenêtre.
        /// </summary>
        private double width;

        /// <summary>
        /// La hauteur de la fenêtre.
        /// </summary>
        private double height;

        /// <summary>
        /// La position de la fenetre.
        /// </summary>
        private Point position;

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public WindowConfiguration() { }

        /// <summary>
        /// Propriete Height
        /// </summary>
        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// Propriete Width.
        /// </summary>
        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

    }
}
