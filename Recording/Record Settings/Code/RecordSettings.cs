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
        /// This const storages the time mode in <see cref="mode_postTrigger">mode_postTrigger</see>/>.
        /// </summary>
        const string MODE_TIME = "TIME";

        /// <summary>
        /// This const storages the frame mode in <see cref="mode_postTrigger">mode_postTrigger</see>/>.
        /// </summary>
        const string MODE_FRAME = "FRAMES";

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
        /// This variable storages the mode of post trigger.
        /// </summary>
        string mode_postTrigger;

        /// <summary>
        /// Esta variable indica el tiempo para la finalización de la grabación.
        /// </summary>
        double value_postTrigger;

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
            outputFormat = MIL.M_FILE_FORMAT_MP4;
            fps = 0;
            value_postTrigger = 0;
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
                switch (Mode_postTrigger)
                {
                    case MODE_FRAME:
                        return value_postTrigger;

                    case MODE_TIME:

                        switch (UnitTimeStop)
                        {
                            case "Segundos":
                                return value_postTrigger;
                            case "Minutos":
                                return value_postTrigger * 60;
                            case "Horas":
                                return value_postTrigger * 3600;
                        }

                        break;
                }
                return 0;
            }

            set => value_postTrigger = value;
        }
        public string Root { get => root; set => root = value; }
        public string UnitTimeStop { get => unitTimeStop; set => unitTimeStop = value; }
        public double Pretrigger { get => pretrigger; set => pretrigger = value; }
        public string Mode_postTrigger { get => mode_postTrigger; set => mode_postTrigger = value; }
    }
}
