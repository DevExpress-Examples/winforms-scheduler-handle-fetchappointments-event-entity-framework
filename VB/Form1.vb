Imports System
Imports System.Linq
Imports DevExpress.XtraScheduler
Imports System.Data.Entity

Namespace SchedulerEntityFramework

    Public Partial Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Private carsXtraSchedulingEntities As CarsXtraSchedulingEntities1 = New CarsXtraSchedulingEntities1()

        Public Sub New()
            InitializeComponent()
            schedulerControl1.Start = New DateTime(2017, 3, 20)
            schedulerControl1.ActiveViewType = SchedulerViewType.FullWeek
            AddHandler schedulerControl1.Storage.FetchAppointments, AddressOf Storage_FetchAppointments
            SetupMappings()
            carsXtraSchedulingEntities.Cars.Load()
            schedulerControl1.Storage.Resources.DataSource = carsXtraSchedulingEntities.Cars.Local
            AddHandler schedulerControl1.Storage.AppointmentsChanged, AddressOf schedulerStorage1_AppointmentsChangedInsertedDeleted
            AddHandler schedulerControl1.Storage.AppointmentsInserted, AddressOf schedulerStorage1_AppointmentsChangedInsertedDeleted
            AddHandler schedulerControl1.Storage.AppointmentsDeleted, AddressOf schedulerStorage1_AppointmentsChangedInsertedDeleted
        End Sub

        Private Sub schedulerStorage1_AppointmentsChangedInsertedDeleted(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            carsXtraSchedulingEntities.SaveChanges()
        End Sub

        Private Sub Storage_FetchAppointments(ByVal sender As Object, ByVal e As FetchAppointmentsEventArgs)
            Dim startTime As Date = e.Interval.Start
            Dim endTime As Date = e.Interval.End
            Dim entities = carsXtraSchedulingEntities.CarSchedulings.Where(Function(entity) entity.EventType = 1 OrElse entity.EventType <> 1 AndAlso entity.OriginalStartTime >= startTime AndAlso entity.OriginalStartTime < endTime OrElse entity.OriginalEndTime > startTime AndAlso entity.OriginalEndTime <= endTime)
            entities.Load()
            Dim collection = carsXtraSchedulingEntities.CarSchedulings.Local.ToBindingList()
            schedulerControl1.Storage.Appointments.DataSource = collection
            Text = String.Format("{0} appointments are loaded for {1} interval", collection.Count, e.Interval)
        End Sub

        Private Sub SetupMappings()
            schedulerStorage1.Appointments.Mappings.Subject = "Subject"
            schedulerStorage1.Appointments.Mappings.Description = "Description"
            schedulerStorage1.Appointments.Mappings.Location = "Location"
            schedulerStorage1.Appointments.Mappings.Start = "StartTime"
            schedulerStorage1.Appointments.Mappings.End = "EndTime"
            schedulerStorage1.Appointments.Mappings.AllDay = "AllDay"
            schedulerStorage1.Appointments.Mappings.Label = "Label"
            schedulerStorage1.Appointments.Mappings.Status = "Status"
            schedulerStorage1.Appointments.Mappings.Type = "EventType"
            schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo"
            schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo"
            schedulerStorage1.Appointments.Mappings.ResourceId = "CarId"
            schedulerStorage1.Appointments.Mappings.OriginalOccurrenceStart = "OriginalStartTime"
            schedulerStorage1.Appointments.Mappings.OriginalOccurrenceEnd = "OriginalEndTime"
            schedulerStorage1.Resources.Mappings.Id = "ID"
            schedulerStorage1.Resources.Mappings.Caption = "Model"
        End Sub
    End Class
End Namespace
