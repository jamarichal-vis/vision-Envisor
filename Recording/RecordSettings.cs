using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recording
{
    public class RecordSettings
    {

        /// <summary>
        /// Esta variable almacena el tipo de record que se quiere grabar. Vídeo o secuencia de imágenes.
        /// </summary>
        string type;

        /// <summary>
        /// Este atributo indica el formato de salida.
        /// </summary>
        string outputFormat;

        /// <summary>
        /// Este atributo almacena los fps a los que se grabará. En caso de que esta variable tenga su valor en -1, se grabará con los fps de la
        /// cámara actual. En caso de que esta variable tenga algún valor positivo, la grabación se realizará con los fps indicados.
        /// </summary>
        double fps;

        /// <summary>
        /// Esta variable indica el tiempo para la finalización de la grabación.
        /// </summary>
        double timeStop;

        string unitTimeStop;

        /// <summary>
        /// Ruta donde se guardará la grabación.
        /// </summary>
        string root;

        public RecordSettings()
        {
            Type = "Vídeo";
            outputFormat = "AVI";
            fps = 10;
            timeStop = 15;
            UnitTimeStop = "Segundos";
            Root = @"C:\Recording\Records";
        }

        public string Type { get => type; set => type = value; }
        public string OutputFormat { get => outputFormat; set => outputFormat = value; }
        public double Fps { get => fps; set => fps = value; }
        public double TimeStop { get => timeStop; set => timeStop = value; }
        public string Root { get => root; set => root = value; }
        public string UnitTimeStop { get => unitTimeStop; set => unitTimeStop = value; }
    }
}
