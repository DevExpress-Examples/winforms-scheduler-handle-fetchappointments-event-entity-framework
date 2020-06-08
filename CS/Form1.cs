using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using System.Data.Entity;


namespace SchedulerEntityFramework {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        private CarsXtraSchedulingEntities1 carsXtraSchedulingEntities = new CarsXtraSchedulingEntities1();

        public Form1() {
            InitializeComponent();

            schedulerControl1.Start = new DateTime(2017,3,20);
            schedulerControl1.ActiveViewType = SchedulerViewType.FullWeek;
            schedulerControl1.Storage.FetchAppointments += Storage_FetchAppointments;
            
            SetupMappings();
            carsXtraSchedulingEntities.Cars.Load();
            schedulerControl1.Storage.Resources.DataSource = carsXtraSchedulingEntities.Cars.Local;
            
            schedulerControl1.Storage.AppointmentsChanged += schedulerStorage1_AppointmentsChangedInsertedDeleted;
            schedulerControl1.Storage.AppointmentsInserted += schedulerStorage1_AppointmentsChangedInsertedDeleted;
            schedulerControl1.Storage.AppointmentsDeleted += schedulerStorage1_AppointmentsChangedInsertedDeleted;
        }
 
       
        private void schedulerStorage1_AppointmentsChangedInsertedDeleted(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e) {
            carsXtraSchedulingEntities.SaveChanges();
        }
        private void Storage_FetchAppointments(object sender, FetchAppointmentsEventArgs e) {
            DateTime startTime = e.Interval.Start;
            DateTime endTime = e.Interval.End;

            var entities = carsXtraSchedulingEntities.CarSchedulings.Where(entity => (entity.EventType == 1) ||
                (entity.EventType != 1 &&
                (entity.OriginalStartTime >= startTime && entity.OriginalStartTime < endTime) || (entity.OriginalEndTime > startTime && entity.OriginalEndTime <= endTime)));
            
            entities.Load();
            var collection =  carsXtraSchedulingEntities.CarSchedulings.Local.ToBindingList();
            schedulerControl1.Storage.Appointments.DataSource =collection;
            Text = String.Format("{0} appointments are loaded for {1} interval", collection.Count, e.Interval);
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
            this.schedulerStorage1.Appointments.Mappings.OriginalOccurrenceStart = "OriginalStartTime";
            this.schedulerStorage1.Appointments.Mappings.OriginalOccurrenceEnd = "OriginalEndTime";
            this.schedulerStorage1.Resources.Mappings.Id = "ID";
            this.schedulerStorage1.Resources.Mappings.Caption = "Model";

        }
    }
}