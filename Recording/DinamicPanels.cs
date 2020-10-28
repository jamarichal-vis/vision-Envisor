using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recording
{
    class DinamicPanels
    {
        private const int ONLY_ONE_CAMERA = 1;

        /// <summary>
        /// Matriz de paneles que forman el grid
        /// </summary>
        private Panel[,] panels;

        /// <summary>
        /// Gráficos para pintar detrás de los paneles
        /// </summary>
        private PictureBox[,] pictureBoxes;

        /// <summary>
        /// Texto para introducir junto a cada panel
        /// </summary>
        private Label[,] labels;

        private int n_connected_cam = 0;

        /* Accessor para el número de cámaras del sistema */
        public int N_connected_cam { get => n_connected_cam; set => n_connected_cam = value; }
        public Panel[,] Panels { get => panels; set => panels = value; }
        public PictureBox[,] PictureBoxes { get => pictureBoxes; set => pictureBoxes = value; }
        public Label[,] Labels { get => labels; set => labels = value; }

        /// <summary>
        /// Evento para asignar a los paneles cada vez que se clicke encima de ellos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void getEvent(object sender, EventArgs e);

        public event getEvent ClickEvent;

        /// <summary>
        /// Constructor de la clase. Se le asignan el número de cámaras que tendrá el sistema
        /// </summary>
        /// <param name="visualForm"> Formulario donde se produce el evento </param>
        /// <param name="_n_connected_cam"> Número de cámaras del sistema </param>
        public DinamicPanels(int _n_connected_cam) => this.N_connected_cam = _n_connected_cam;

        /// <summary>
        ///
        /// </summary>
        /// <param name="numElements"></param>
        /// <returns></returns>
        public int[] GetGridDivison(int numElements)
        {
            int[] gridDivision = new int[] { numElements, 1 }; //rows, cols

            gridDivision[0] = (int)Math.Ceiling((double)gridDivision[0] / 2);
            gridDivision[1] = numElements - gridDivision[0];

            return gridDivision;
        }

        /// <summary>
        /// Función para crear el conjunto de los paneles. Sacamos el numero de filas y columnas
        /// </summary>
        /// <returns> Devuelve una matriz de paneles por filas y columnas </returns>
        public Panel[,] CreatePanelGrid()
        {
            int rows = 1; //Numero de filas
            int columns = 1; //Numero de columnas
            int camera_number_row = 2; //numero para saber con que cantidad de camaras tenemos que sumar una fila
            int camera_number_column = 1; //numero para saber con que cantidad de camaras tenemos que sumar una columna
            int row_counter = 0; //variable sumador row
            int column_counter = 0; //variable sumador column

            if (this.N_connected_cam > ONLY_ONE_CAMERA)
            {
                for (int i = 2; i <= this.N_connected_cam; i++)
                {
                    row_counter++;
                    column_counter++;
                    if (camera_number_row == row_counter)
                    {
                        row_counter = 0;
                        rows++;
                        camera_number_row += 2;
                    }
                    if (camera_number_column == column_counter)
                    {
                        column_counter = 0;
                        columns++;
                        camera_number_column += 2;
                    }
                }
                panels = new Panel[rows, columns];
                pictureBoxes = new PictureBox[rows, columns];
                labels = new Label[rows, columns];
                return panels;
            }

            /* En caso de que haya una sola cámara (o cero) no se procede a hacer nada y devolvemos un solo panel */
            panels = new Panel[1, 1];
            pictureBoxes = new PictureBox[1, 1];
            labels = new Label[1, 1];
            return panels;
        }

        /// <summary>
        /// Función para rellenar y pintar los paneles en función de las dimensiones del control del atributo
        /// </summary>
        /// <param name="panelPaneles"> Control de tipo Panel para sacar las dimensiones </param>
        public void FillGrid(Panel panelPaneles)
        {
            /*Quitamos los bordes del total*/
            float borderW = 0.05F * panelPaneles.Width;
            float borderH = 0.05F * panelPaneles.Height;
            int totalW = panelPaneles.Width - (int)(2 * borderW);
            int totalH = panelPaneles.Height - (int)(2 * borderH);
            /* GetLength 0 -> fila // GetLength 1 -> columna */
            int num_panels_column = panels.GetLength(1);
            int num_panels_row = panels.GetLength(0);
            int panel_Heigh = totalH / num_panels_row;
            int panel_Width = totalW / num_panels_column;

            double coeficient = this.N_connected_cam > 9 ? 0.1 : 0.2;
            int panel_distance_Horizontal = (int)(coeficient * panel_Width);

            /* Aplicamos una correccion a los paneles para que mantengan una proporcion de 4:3 */
            /*Eliminamos el 20% para dejar espacios entre los paneles*/
            panel_Width = panel_Width - panel_distance_Horizontal;
            panel_Heigh = (int)(panel_Width / 1.33);

            int panel_distance_Vertical;// = (int)((0.2) * panel_Heigh);

            if (panel_Heigh * num_panels_row < totalH)
            {
                panel_distance_Vertical = (totalH - panel_Heigh * num_panels_row) / (num_panels_row - 1);
            }
            else
                panel_distance_Vertical = (int)((0.2) * panel_Heigh);
            /* Distancias Horizontal/Vertical entre paneles */
            //int distance_H = (int)(0.2 * panel_Width);
            //int distance_V = (int)(0.2 * panel_Heigh);
            //int panel_distance_H = distance_H / (num_panels_column - 1);// (panelPaneles.Width - (panel_Width * panels.GetLength(1))) / (panels.GetLength(1) + 1);
            //int panel_distance_V = (totalH - (panel_Heigh * panels.GetLength(0))) / (panels.GetLength(0) + 1);

            /* Sacamos la distancia de la fuente a partir de la distancia entre paneles */
            int font_size = panel_distance_Vertical / 2;

            //panel_distance_V = N_connected_cam == 12 ? panel_distance_V : panel_distance_V + font_size;

            int panel_number = 1;

            //Recorremos todas las filas
            for (int i = 0; i < num_panels_row; i++)
            {
                //Recorremos todas las columnas
                for (int j = 0; j < num_panels_column; j++)
                {
                    /* Decimal para establecer el número del panel.
                     * En caso de que el numero sea inferior a 9 debemos añardir un 0.
                     * Los nombres de los paneles se tienen que componer de dos números porque se saca su índice a partir de los dos últimos caracteres.
                     */
                    string str_panel_number_decimal = panel_number <= 9 ? "0" : "";

                    //if (panel_number > 9)
                    //    str_panel_number_decimal = "";
                    //else
                    //    str_panel_number_decimal = "0";

                    /* Asignamos el nombre del panel */
                    string name = "panel" + str_panel_number_decimal + panel_number.ToString();

                    /* Restamos uno debido a que el numero de cámaras empiezan con indice 0 */
                    if (panel_number - 1 < this.N_connected_cam)
                    {
                        int widthchange = this.N_connected_cam == 12 ? 0 : (int)(1.33 * font_size) * 2;
                        int heightchange = this.N_connected_cam == 12 ? 0 : font_size * 2;
                        int locationXchange = this.N_connected_cam == 12 ? 0 : true ? 0 : (font_size * (j == 0 ? j : 2));
                        int locationYchange = this.N_connected_cam == 12 ? 0 : (font_size * (i == 0 ? i : 2));

                        CreatePictureBoxes(panelPaneles,
                            "pictureBox" + str_panel_number_decimal + panel_number.ToString(),
                            panel_Width,
                            panel_Heigh,
                            (int)borderW + j * panel_distance_Horizontal + j * panel_Width,
                            (int)borderH + i * panel_distance_Vertical + i * panel_Heigh,
                            i, j);

                        CreatePanel(panelPaneles,
                            "panel" + str_panel_number_decimal + panel_number.ToString(),
                            panel_Width - panel_Width / 13,
                            panel_Heigh - panel_Heigh / 13,
                            pictureBoxes[i, j].Location.X + (pictureBoxes[i, j].Width - (panel_Width - panel_Width / 13)) / 4 - 2,
                            pictureBoxes[i, j].Location.Y + (pictureBoxes[i, j].Height - (panel_Heigh - panel_Heigh / 13)) / 4,
                            i, j);

                        CreateLabels(panelPaneles,
                            "label" + str_panel_number_decimal + panel_number.ToString(),
                            pictureBoxes[i, j].Location.X,
                            pictureBoxes[i, j].Location.Y + pictureBoxes[i, j].Height,
                            i, j, panel_distance_Vertical / 3, pictureBoxes[i, j].Size.Width);
                    }
                    /* El resto de paneles los creamos nulos hasta rellenar las filas/ columnas */
                    else
                    {
                        panels[i, j] = null;
                        pictureBoxes[i, j] = null;
                        labels[i, j] = null;
                    }
                    panel_number++;
                }
            }
            /* Traemos los labels al frente */
            GetControlsToFront(labels);
            /* Traemos al frente los PictureBoxes */
            GetControlsToFront(pictureBoxes);
            /* Traemos al frente los paneles para que se situen delante de los PictureBoxes */
            GetControlsToFront(panels);
        }

        /// <summary>
        /// Función para crear un panel
        /// </summary>
        /// <param name="panelPaneles"> Control de tipo Panel donde se va a crear el panel </param>
        /// <param name="panel_name"> Nombre del panel creado </param>
        /// <param name="width"> Anchura del panel creado </param>
        /// <param name="heigh"> Altura del panel creado </param>
        /// <param name="location_x"> Localización en el eje X del panel creado </param>
        /// <param name="location_y"> Localización en el eje Y del panel creado </param>
        /// <param name="row"> Posición en la fila de la matriz del panel creado </param>
        /// <param name="column"> Posición en la columna de la matriz del panel creado </param>
        public void CreatePanel(Panel panelPaneles, string panel_name, int width, int heigh, int location_x, int location_y, int row, int column)
        {
            int dif_x = width - pictureBoxes[row, column].Width;
            int dif_y = heigh - pictureBoxes[row, column].Height;
            panels[row, column] = new System.Windows.Forms.Panel();
            panelPaneles.Controls.Add(panels[row, column]);
            panels[row, column].Location = new System.Drawing.Point(location_x - dif_x / 2 - 2, location_y - dif_y / 2);
            panels[row, column].BorderStyle = BorderStyle.FixedSingle;
            panels[row, column].Name = panel_name;
            panels[row, column].Size = new System.Drawing.Size(width, heigh);
            panels[row, column].TabIndex = 4;
            panels[row, column].Cursor = System.Windows.Forms.Cursors.Hand;
            //panels[row, column].BackgroundImage = Properties.Resources.disconnected;
            panels[row, column].BackgroundImageLayout = ImageLayout.Stretch;
            /* Asignamos el evento de clickar encima del panel */
            panels[row, column].MouseClick += new System.Windows.Forms.MouseEventHandler(ClickEvent);
        }

        /// <summary>
        /// Función para crear los PictureBox que van detras de cada panel para indicar su color
        /// </summary>
        /// <param name="panelPaneles"> Control de tipo Panel donde se va a crear el PictureBox </param>
        /// <param name="box_name"> Nombre del PictureBox creado </param>
        /// <param name="width"> Anchura del PictureBox creado </param>
        /// <param name="heigh"> Altura del PictureBox creado </param>
        /// <param name="location_x"> Localización en el eje X del PictureBox creado </param>
        /// <param name="location_y"> Localización en el eje Y del PictureBox creado </param>
        /// <param name="row"> Posición en la fila de la matriz del PictureBox creado </param>
        /// <param name="column"> Posición en la columna de la matriz del PictureBox creado </param>
        public void CreatePictureBoxes(Panel panelPaneles, string box_name, int width, int heigh, int location_x, int location_y, int row, int column)
        {
            pictureBoxes[row, column] = new System.Windows.Forms.PictureBox();
            panelPaneles.Controls.Add(pictureBoxes[row, column]);
            pictureBoxes[row, column].Location = new System.Drawing.Point(location_x, location_y);
            pictureBoxes[row, column].BorderStyle = BorderStyle.FixedSingle;
            pictureBoxes[row, column].Name = box_name;
            pictureBoxes[row, column].Size = new System.Drawing.Size(width, heigh);
            pictureBoxes[row, column].TabIndex = 4;
        }

        /// <summary>
        /// Función para crear los labels que acompañan a cada panel
        /// </summary>
        /// <param name="panelPaneles"> Control de tipo Panel donde se va a crear el Label </param>
        /// <param name="box_name"> Nombre del Label creado </param>
        /// <param name="location_x"> Localización en el eje X del Label creado </param>
        /// <param name="location_y"> Localización en el eje Y del Label creado </param>
        /// <param name="row"> Posición en la fila de la matriz del Label creado </param>
        /// <param name="column"> Posición en la columna de la matriz del Label creado </param>
        /// <param name="font_size"> Tamaño de la fuente </param>
        public void CreateLabels(Panel panelPaneles, string box_name, int location_x, int location_y, int row, int column, int font_size, int SizeWidthControl)
        {
            labels[row, column] = new System.Windows.Forms.Label();
            panelPaneles.Controls.Add(labels[row, column]);
            labels[row, column].BorderStyle = BorderStyle.None;
            labels[row, column].Name = box_name;
            labels[row, column].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
            labels[row, column].Text = "IP:";
            labels[row, column].Location = new System.Drawing.Point(location_x, location_y + labels[row, column].Height / 8);
            labels[row, column].ForeColor = Color.FromArgb(0, 0, 0);
            labels[row, column].TabIndex = 4;
            labels[row, column].Size = new Size(SizeWidthControl, labels[row, column].Height);
        }

        /// <summary>
        /// Función para traer los controles creados al frente del formulario
        /// </summary>
        /// <param name="control"> Grupo de controles </param>
        public void GetControlsToFront(Control[,] control)
        {
            int control_number = 1;
            for (int i = 0; i < panels.GetLength(0); i++)
            {
                for (int j = 0; j < panels.GetLength(1); j++)
                {
                    if (control_number - 1 < this.N_connected_cam)
                    {
                        control[i, j].BringToFront();
                        control_number++;
                    }
                }
            }
        }

        /// <summary>
        /// Función para llevar los controles creados al fondo del formulario
        /// </summary>
        /// <param name="control"></param>
        public void GetControlsToBack(Control[,] control)
        {
            int control_number = 1;
            for (int i = 0; i < panels.GetLength(0); i++)
            {
                for (int j = 0; j < panels.GetLength(1); j++)
                {
                    if (control_number - 1 < this.N_connected_cam)
                    {
                        control[i, j].SendToBack();
                        control_number++;
                    }
                }
            }
        }
    }
}
