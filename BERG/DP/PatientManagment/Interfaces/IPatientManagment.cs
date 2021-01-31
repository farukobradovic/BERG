using BERG.Models;
using BERG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BERG.DP.PatientManagment.Interfaces
{
    public interface IPatientManagment
    {
        List<Patient> ListAll();
        void AddPatient(PatientViewModel model);
        void DeletePatient(int patientID);
        Patient GetPatient(int patientID);
        void UpdatePatient(PatientEditViewModel model);
    }
}
