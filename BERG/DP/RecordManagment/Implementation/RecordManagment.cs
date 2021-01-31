using BERG.Data;
using BERG.DP.RecordManagment.Interfaces;
using BERG.Models;
using BERG.ViewModels.MedicalRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BERG.DP.RecordManagment.Implementation
{
    public class RecordManagment : IRecordManagment
    {
        private readonly DataContext db;

        public RecordManagment(DataContext db)
        {
            this.db = db;
        }

        public void AddRecord(MedicalRecordViewModel model)
        {
            var appo = db.Appointments.SingleOrDefault(c => c.Id == model.AppointmentID);
            var record = new MedicalRecord
            {
                Description = model.Description,
                CreatedAt = DateTime.Now,
                AppointmentID = appo.Id
            };

            db.Records.Add(record);
            db.SaveChanges();

        }

   

    }
}
