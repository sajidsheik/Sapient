using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalTrackingSystemProviders
{
    interface IMedicine
    {
        List<Medicine> ViewMedicines();

        Medicine SearchMedicine();

        void AddMedicine();

        void EditMedicine();
    }
}
