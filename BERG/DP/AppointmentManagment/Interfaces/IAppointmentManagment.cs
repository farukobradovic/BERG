using BERG.Models;
using BERG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BERG.DP.AppointmentManagment.Interfaces
{
    public interface IAppointmentManagment
    {
        public List<Appointment> ListAllAppointemnts();
        public void AddAppointent(AppointementViewModel model);
        public Appointment GetAppointmentByID(int appointmentID);
        public void Edit(AppointementViewModel model);
        public bool IsAppointmentGotRecord(int appointmentID);
        public List<Appointment> GetAppointmentsByDate(AppointementViewModel model);
    }
}
