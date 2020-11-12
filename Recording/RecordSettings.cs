using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrox.MatroxImagingLibrary;

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
        MIL_INT outputFormat;

        /// <summary>
        /// Este atributo almacena los fps a los que se grabará. En caso de que esta variable tenga su valor en -1, se grabará con los fps de la
        /// cámara actual. En caso de que esta variable tenga algún valor positivo, la grabación se realizará con los fps indicados.
        /// </summary>
        double fps;

        /// <summary>
        /// Esta variable indica el tiempo para la finalización de la grabación.
        /// </summary>
        double timeStop;

        /// <summary>
        /// Esta variable almacena las unidades de tiempo que se quiere 
        /// </summary>
        string unitTimeStop;

        /// <summary>
        /// Ruta donde se guardará la grabación.
        /// </summary>
        string root;

        /// <summary>
        /// Esta función contiene el valor de pretrigger.
        /// </summary>
        double pretrigger;

        public RecordSettings()
        {
            Type = "Vídeo";
            outputFormat = MIL.M_AVI_MJPG;
            fps = 10;
            timeStop = 15;
            UnitTimeStop = "Segundos";
            Root = @"C:\Recording\Records";
        }

        public string Type { get => type; set => type = value; }
        public MIL_INT OutputFormat { get => outputFormat; set => outputFormat = value; }
        public double Fps { get => fps; set => fps = value; }
        public double TimeStop
        {
            get
            {
                switch (UnitTimeStop)
                {
                    case "Segundos":
                        return timeStop;
                    case "Minutos":
                        return timeStop * 60;
                    case "Horas":
                        return timeStop * 3600;
                }

                return timeStop;
            }

            set => timeStop = value;
        }
        public string Root { get => root; set => root = value; }
        public string UnitTimeStop { get => unitTimeStop; set => unitTimeStop = value; }
        public double Pretrigger { get => pretrigger; set => pretrigger = value; }
    }
}
