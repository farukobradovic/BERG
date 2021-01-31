using BERG.Data;
using BERG.DP.AppointmentManagment.Interfaces;
using BERG.Models;
using BERG.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BERG.DP.AppointmentManagment.Implementation
{
    public class AppointmentManagment : IAppointmentManagment
    {
        private readonly DataContext db;

        public AppointmentManagment(DataContext db)
        {
            this.db = db;
        }

        public List<Appointment> ListAllAppointemnts()
        {
            List<BERG.Models.Appointment> appointemnts = db.Appointments.Include(c => c.User).Include(c => c.Patient).ToList();
            return appointemnts;
        }

        public void AddAppointent(AppointementViewModel model)
        {
            var appointment = new Appointment
            {
                Time = model.Time,
                UserID = model.UserID,
                PatientID = model.PatientID,
                Urgently = model.Urgent
            };

            db.Appointments.Add(appointment);
            db.SaveChanges();
        }

        public Appointment GetAppointmentByID(int appointmentID)
        {
            var appo = db.Appointments.Include(c => c.Patient).Include(c => c.User).SingleOrDefault(c => c.Id == appointmentID);
            return appo;
        }

        public void Edit(AppointementViewModel model)
        {
            var appo = db.Appointments.SingleOrDefault(c => c.Id == model.AppointmentID);
            appo.Time = model.Time;
            appo.UserID = model.UserID;
            appo.PatientID = model.PatientID;
            appo.Urgently = model.Urgent;

            db.SaveChanges();
        }

        public bool IsAppointmentGotRecord(int appointmentID)
        {
            var rec = db.Records.SingleOrDefault(c => c.AppointmentID == appointmentID);
            if (rec != null)
                return true;
            return false;
        }

        public List<Appointment> GetAppointmentsByDate(AppointementViewModel model)
        {
            List<Appointment> appos = db.Appointments
                .Where(c => c.Time.CompareTo(model.From) > 0 && c.Time.CompareTo(model.To) < 0)
                .Include(c => c.User)
                .Include(c => c.Patient).ToList();
            return appos;
        }
    }
}
