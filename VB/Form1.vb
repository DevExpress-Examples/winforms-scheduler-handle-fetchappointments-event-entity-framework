Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler
Imports System.Data.Entity

Namespace SchedulerEntityFramework

    Public Partial Class Form1
        Inherits Form

        Private carsXtraSchedulingEntities As CarsXtraSchedulingEntities1 = New CarsXtraSchedulingEntities1()

        Public Sub New()
            InitializeComponent()
            schedulerControl1.Start = Date.Now
            AddHandler schedulerControl1.Storage.FetchAppointments, AddressOf Storage_FetchAppointments
            SetupMappings()
            carsXtraSchedulingEntities.Cars.Load()
            schedulerControl1.Storage.Resources.DataSource = carsXtraSchedulingEntities.Cars.Local
            AddHandler schedulerControl1.Storage.AppointmentsChanged, AddressOf schedulerStorage1_AppointmentsChangedinsertedDeleted
            AddHandler schedulerControl1.Storage.AppointmentsInserted, AddressOf schedulerStorage1_AppointmentsChangedinsertedDeleted
            AddHandler schedulerControl1.Storage.AppointmentsDeleted, AddressOf schedulerStorage1_AppointmentsChangedinsertedDeleted
            AddHandler schedulerControl1.Storage.AppointmentChanging, AddressOf Storage_AppointmentChanging
        End Sub

        Private originalStart As Date

        Private originalEnd As Date

        Private Sub UpdateOriginalTimeInterval(ByVal apt As Appointment)
            Dim occurrence As Appointment = apt.RecurrencePattern.GetOccurrence(apt.RecurrenceIndex)
            originalStart = occurrence.Start
            originalEnd = occurrence.End
        End Sub

        Private Sub InitializeCustomFields(ByVal apt As Appointment)
            apt.CustomFields("OriginalStartTime") = originalStart
            apt.CustomFields("OriginalEndTime") = originalEnd
        End Sub

        Private Sub Storage_AppointmentChanging(ByVal sender As Object, ByVal e As PersistentObjectCancelEventArgs)
            Dim apt As Appointment = TryCast(e.Object, Appointment)
            If apt.Type = AppointmentType.Occurrence Then
                UpdateOriginalTimeInterval(apt)
            ElseIf apt.Type = AppointmentType.ChangedOccurrence AndAlso apt.CustomFields("OriginalStartTime") Is Nothing AndAlso apt.CustomFields("OriginalEndTime") Is Nothing Then
                InitializeCustomFields(apt)
            End If
        End Sub

        Private Sub schedulerStorage1_AppointmentsChangedinsertedDeleted(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            carsXtraSchedulingEntities.SaveChanges()
        End Sub

        Private Sub Storage_FetchAppointments(ByVal sender As Object, ByVal e As FetchAppointmentsEventArgs)
            Dim startTime As Date = e.Interval.Start
            Dim endTime As Date = e.Interval.End
            Dim entities = carsXtraSchedulingEntities.CarSchedulings.Where(Function(entity) entity.EventType = 1 OrElse entity.EventType <> 3 AndAlso entity.StartTime >= startTime AndAlso entity.StartTime < endTime OrElse entity.EndTime >= startTime AndAlso entity.EndTime < endTime OrElse entity.EventType = 3 AndAlso (entity.OriginalStartTime >= startTime AndAlso entity.OriginalStartTime < endTime OrElse entity.OriginalEndTime >= startTime AndAlso entity.OriginalEndTime < endTime))
            entities.Load()
            schedulerControl1.Storage.Appointments.DataSource = carsXtraSchedulingEntities.CarSchedulings.Local.ToBindingList()
            e.ForceReloadAppointments = True
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
            schedulerStorage1.Resources.Mappings.Id = "ID"
            schedulerStorage1.Resources.Mappings.Caption = "Model"
            schedulerStorage1.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("OriginalStartTime", "OriginalStartTime"))
            schedulerStorage1.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("OriginalEndTime", "OriginalEndTime"))
        End Sub
    End Class
End Namespace
