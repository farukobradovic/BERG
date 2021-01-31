using BERG.ViewModels.MedicalRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BERG.DP.RecordManagment.Interfaces
{
    public interface IRecordManagment
    {
        public void AddRecord(MedicalRecordViewModel model);
    }
}
