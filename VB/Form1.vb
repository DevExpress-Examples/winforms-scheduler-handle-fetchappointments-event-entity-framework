Imports System
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler

Namespace SchedulerEntityFramework

    Public Partial Class Form1
        Inherits Form

        Private carsXtraSchedulingEntities As CarsXtraSchedulingEntities = New CarsXtraSchedulingEntities()

        Private lastFetchedInterval As TimeInterval = New TimeInterval()

        Public Sub New()
            InitializeComponent()
            SetupMappings()
            schedulerControl1.Storage.Appointments.DataSource = New BindingSource()
            schedulerControl1.Storage.Resources.DataSource = carsXtraSchedulingEntities.Cars
            schedulerControl1.Start = New DateTime(2008, 7, 1)
        End Sub

        Private Sub schedulerStorage1_AppointmentsInserted(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            carsXtraSchedulingEntities.SaveChanges()
            For i As Integer = 0 To e.Objects.Count - 1
                Dim apt As Appointment = CType(e.Objects(i), Appointment)
                Dim source As CarScheduling = CType(apt.GetSourceObject(schedulerStorage1), CarScheduling)
                schedulerStorage1.SetAppointmentId(apt, source.ID)
            Next
        End Sub

        Private Sub schedulerStorage1_AppointmentsChanged(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            carsXtraSchedulingEntities.SaveChanges()
        End Sub

        Private Sub schedulerStorage1_AppointmentsDeleted(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            carsXtraSchedulingEntities.SaveChanges()
        End Sub

        Private Sub Storage_FetchAppointments(ByVal sender As Object, ByVal e As FetchAppointmentsEventArgs)
            Dim bindingSource As BindingSource = TryCast(schedulerControl1.Storage.Appointments.DataSource, BindingSource)
            If bindingSource Is Nothing OrElse lastFetchedInterval.Contains(e.Interval) Then Return
            Dim margin As TimeSpan = TimeSpan.FromDays(0) ' TimeSpan.FromDays(1) 
            lastFetchedInterval = New TimeInterval(e.Interval.Start - margin, e.Interval.End + margin)
            Dim entities = From entity In carsXtraSchedulingEntities.CarSchedulings Where entity.EventType = 1 OrElse entity.StartTime < lastFetchedInterval.End AndAlso entity.EndTime > lastFetchedInterval.Start Select entity
            bindingSource.DataSource = entities
        End Sub

        Private Sub SetupMappings()
            schedulerStorage1.Appointments.Mappings.AppointmentId = "ID"
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
            schedulerStorage1.Resources.Mappings.Id = "ID"
            schedulerStorage1.Resources.Mappings.Caption = "Model"
        End Sub
    End Class
End Namespace
