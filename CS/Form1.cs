using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using System.Data.Entity;


namespace SchedulerEntityFramework {
    public partial class Form1 : Form {
        private CarsXtraSchedulingEntities1 carsXtraSchedulingEntities = new CarsXtraSchedulingEntities1();

        public Form1() {
            InitializeComponent();
            
            schedulerControl1.Start = DateTime.Now;
            
            schedulerControl1.Storage.FetchAppointments += Storage_FetchAppointments;
            
            SetupMappings();
            carsXtraSchedulingEntities.Cars.Load();
            schedulerControl1.Storage.Resources.DataSource = carsXtraSchedulingEntities.Cars.Local;

            schedulerControl1.Storage.AppointmentsChanged += schedulerStorage1_AppointmentsChangedinsertedDeleted;
            schedulerControl1.Storage.AppointmentsInserted += schedulerStorage1_AppointmentsChangedinsertedDeleted;
            schedulerControl1.Storage.AppointmentsDeleted += schedulerStorage1_AppointmentsChangedinsertedDeleted;
            schedulerControl1.Storage.AppointmentChanging += Storage_AppointmentChanging;
        }


        DateTime originalStart;
        DateTime originalEnd;
        private void UpdateOriginalTimeInterval(Appointment apt) {
                Appointment occurrence = apt.RecurrencePattern.GetOccurrence(apt.RecurrenceIndex);
                originalStart = occurrence.Start;
                originalEnd = occurrence.End;
        }
        private void InitializeCustomFields(Appointment apt) {
                apt.CustomFields["OriginalStartTime"] = originalStart;
                apt.CustomFields["OriginalEndTime"] = originalEnd;
        }
        void Storage_AppointmentChanging(object sender, PersistentObjectCancelEventArgs e) {
            Appointment apt = e.Object as Appointment;
            if(apt.Type == AppointmentType.Occurrence) 
                UpdateOriginalTimeInterval(apt);
            else if(apt.Type == AppointmentType.ChangedOccurrence && apt.CustomFields["OriginalStartTime"] == null && apt.CustomFields["OriginalEndTime"] == null)
                InitializeCustomFields(apt);
        }
        private void schedulerStorage1_AppointmentsChangedinsertedDeleted(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e) {
            carsXtraSchedulingEntities.SaveChanges();
        }
        private void Storage_FetchAppointments(object sender, FetchAppointmentsEventArgs e) {
            DateTime startTime = e.Interval.Start;
            DateTime endTime = e.Interval.End;

            var entities = carsXtraSchedulingEntities.CarSchedulings.Where(entity => (entity.EventType == 1) ||
                ((entity.EventType != 3) && 
                (entity.StartTime >= startTime && entity.StartTime < endTime) || (entity.EndTime >= startTime && entity.EndTime < endTime)) ||
                ((entity.EventType == 3) && 
                ((entity.OriginalStartTime >= startTime && entity.OriginalStartTime < endTime) || (entity.OriginalEndTime >= startTime) && entity.OriginalEndTime < endTime))) ;
   
            entities.Load();
            
            schedulerControl1.Storage.Appointments.DataSource = carsXtraSchedulingEntities.CarSchedulings.Local.ToBindingList();
            e.ForceReloadAppointments = true;
        }

        private void SetupMappings() {
            this.schedulerStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerStorage1.Appointments.Mappings.Description = "Description";
            this.schedulerStorage1.Appointments.Mappings.Location = "Location";
            this.schedulerStorage1.Appointments.Mappings.Start = "StartTime";
            this.schedulerStorage1.Appointments.Mappings.End = "EndTime";
            this.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerStorage1.Appointments.Mappings.Label = "Label";
            this.schedulerStorage1.Appointments.Mappings.Status = "Status";
            this.schedulerStorage1.Appointments.Mappings.Type = "EventType";
            this.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo";
            this.schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo";
            this.schedulerStorage1.Appointments.Mappings.ResourceId = "CarId";
            this.schedulerStorage1.Resources.Mappings.Id = "ID";
            this.schedulerStorage1.Resources.Mappings.Caption = "Model";

            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("OriginalStartTime", "OriginalStartTime"));
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("OriginalEndTime", "OriginalEndTime"));
        }
    }
}