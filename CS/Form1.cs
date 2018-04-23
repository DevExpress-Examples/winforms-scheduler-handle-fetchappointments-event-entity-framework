using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace SchedulerEntityFramework {
    public partial class Form1 : Form {
        private CarsXtraSchedulingEntities carsXtraSchedulingEntities = new CarsXtraSchedulingEntities();
        private TimeInterval lastFetchedInterval = new TimeInterval();

        public Form1() {
            InitializeComponent();

            SetupMappings();

            schedulerControl1.Storage.Appointments.DataSource = new BindingSource();
            schedulerControl1.Storage.Resources.DataSource = carsXtraSchedulingEntities.Cars;

            schedulerControl1.Start = new System.DateTime(2008, 7, 1);
        }

        private void schedulerStorage1_AppointmentsInserted(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e) {
            carsXtraSchedulingEntities.SaveChanges();

            for (int i = 0; i < e.Objects.Count; i++) {
                Appointment apt = (Appointment)e.Objects[i];
                CarScheduling source = (CarScheduling)apt.GetSourceObject(schedulerStorage1);

                schedulerStorage1.SetAppointmentId(apt, source.ID);
            }
        }

        private void schedulerStorage1_AppointmentsChanged(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e) {
            carsXtraSchedulingEntities.SaveChanges();
        }

        private void schedulerStorage1_AppointmentsDeleted(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e) {
            carsXtraSchedulingEntities.SaveChanges();
        }

        private void Storage_FetchAppointments(object sender, FetchAppointmentsEventArgs e) {
            BindingSource bindingSource = schedulerControl1.Storage.Appointments.DataSource as BindingSource;

            if (bindingSource == null || lastFetchedInterval.Contains(e.Interval))
                return;

            TimeSpan margin = TimeSpan.FromDays(0); // TimeSpan.FromDays(1) 
            lastFetchedInterval = new TimeInterval(e.Interval.Start - margin, e.Interval.End + margin);

            var entities = from entity in carsXtraSchedulingEntities.CarSchedulings
                           where entity.EventType == 1 || (entity.StartTime < lastFetchedInterval.End && entity.EndTime > lastFetchedInterval.Start)
                           select entity;

            bindingSource.DataSource = entities;
        }

        private void SetupMappings() {
            this.schedulerStorage1.Appointments.Mappings.AppointmentId = "ID";
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
        }
    }
}