using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrox.MatroxImagingLibrary;

namespace Recording
{
    /// <summary>
    /// Esta clase es creada para identificar una cámara en la clase MilLibrary.
    /// </summary>
    public class Id
    {
        /// <summary>
        /// Posición del sistema dentro de MilLibrary.
        /// </summary>
        private MIL_INT? devNSys;

        /// <summary>
        /// Posición de la cámara dentro de MilLibrary.
        /// </summary>
        private MIL_INT? devNCam;

        /* ACCESS */
        public MIL_INT DevNSys { get => devNSys.Value; set => devNSys = value; }
        public MIL_INT DevNCam { get => devNCam.Value; set => devNCam = value; }

        public Id()
        {
            DevNSys = -1;
            DevNCam = -1;
        }

        public Id(MIL_INT devSys, MIL_INT devCam)
        {
            DevNSys = devSys;
            DevNCam = devCam;
        }

        /// <summary>
        /// Esta función establece los parámetros necesarios para identificar una cñamara en MilApp.
        /// </summary>
        /// <param name="devNSys">Dev del sistema.</param>
        /// <param name="devNCam">Dev de la cámara.</param>
        /// <param name="nameImage">Nombre de la imagen (de la cámara) que quieres que se vea en el panel. Si fuera necesario.</param>
        public void Set(MIL_INT devNSys, MIL_INT devNCam)
        {
            this.DevNSys = devNSys;
            this.DevNCam = devNCam;
        }

        public void Copy(Id id)
        {
            this.DevNSys = id.DevNSys;
            this.DevNCam = id.DevNCam;
        }

        /// <summary>
        /// Esta función establece los valores por defecto.
        /// </summary>
        public void Reset()
        {
            DevNSys = -1;
            DevNCam = -1;
        }

        /// <summary>
        /// Esta función indica si el objeto Id pasado por parámetro es igual al objeto actual.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Equal(Id id)
        {
            if (DevNSys == id.DevNSys && DevNCam == id.DevNCam)
                return true;

            return false;
        }
    }

    class IdEqualityComparer : IEqualityComparer<Id>
    {
        #region IEqualityComparer<Customer> Members

        public bool Equals(Id x, Id y)
        {
            return ((x.DevNSys == y.DevNSys) & (x.DevNCam == y.DevNCam));
        }

        public int GetHashCode(Id obj)
        {
            string combined = obj.DevNSys + "|" + obj.DevNCam;
            return (combined.GetHashCode());
        }

        #endregion
    }
}
