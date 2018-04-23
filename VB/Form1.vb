Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler

Namespace SchedulerEntityFramework
	Partial Public Class Form1
		Inherits Form
		Private carsXtraSchedulingEntities As New CarsXtraSchedulingEntities()
		Private lastFetchedInterval As New TimeInterval()

		Public Sub New()
			InitializeComponent()

			SetupMappings()

			schedulerControl1.Storage.Appointments.DataSource = New BindingSource()
			schedulerControl1.Storage.Resources.DataSource = carsXtraSchedulingEntities.Cars

			schedulerControl1.Start = New System.DateTime(2008, 7, 1)
		End Sub

		Private Sub schedulerStorage1_AppointmentsInserted(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.PersistentObjectsEventArgs) Handles schedulerStorage1.AppointmentsInserted
			carsXtraSchedulingEntities.SaveChanges()

			For i As Integer = 0 To e.Objects.Count - 1
				Dim apt As Appointment = CType(e.Objects(i), Appointment)
				Dim source As CarScheduling = CType(apt.GetSourceObject(schedulerStorage1), CarScheduling)

				schedulerStorage1.SetAppointmentId(apt, source.ID)
			Next i
		End Sub

		Private Sub schedulerStorage1_AppointmentsChanged(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.PersistentObjectsEventArgs) Handles schedulerStorage1.AppointmentsChanged
			carsXtraSchedulingEntities.SaveChanges()
		End Sub

		Private Sub schedulerStorage1_AppointmentsDeleted(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.PersistentObjectsEventArgs) Handles schedulerStorage1.AppointmentsDeleted
			carsXtraSchedulingEntities.SaveChanges()
		End Sub

		Private Sub Storage_FetchAppointments(ByVal sender As Object, ByVal e As FetchAppointmentsEventArgs) Handles schedulerStorage1.FetchAppointments
			Dim bindingSource As BindingSource = TryCast(schedulerControl1.Storage.Appointments.DataSource, BindingSource)

			If bindingSource Is Nothing OrElse lastFetchedInterval.Contains(e.Interval) Then
				Return
			End If

			Dim margin As TimeSpan = TimeSpan.FromDays(0) ' TimeSpan.FromDays(1)
			lastFetchedInterval = New TimeInterval(e.Interval.Start - margin, e.Interval.End + margin)

			Dim entities = _
				From entity In carsXtraSchedulingEntities.CarSchedulings _
				Where entity.EventType = 1 OrElse (entity.StartTime < lastFetchedInterval.End AndAlso entity.EndTime > lastFetchedInterval.Start) _
				Select entity

			bindingSource.DataSource = entities
		End Sub

		Private Sub SetupMappings()
			Me.schedulerStorage1.Appointments.Mappings.AppointmentId = "ID"
			Me.schedulerStorage1.Appointments.Mappings.Subject = "Subject"
			Me.schedulerStorage1.Appointments.Mappings.Description = "Description"
			Me.schedulerStorage1.Appointments.Mappings.Location = "Location"
			Me.schedulerStorage1.Appointments.Mappings.Start = "StartTime"
			Me.schedulerStorage1.Appointments.Mappings.End = "EndTime"
			Me.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay"
			Me.schedulerStorage1.Appointments.Mappings.Label = "Label"
			Me.schedulerStorage1.Appointments.Mappings.Status = "Status"
			Me.schedulerStorage1.Appointments.Mappings.Type = "EventType"
			Me.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo"
			Me.schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo"
			Me.schedulerStorage1.Appointments.Mappings.ResourceId = "CarId"
			Me.schedulerStorage1.Resources.Mappings.Id = "ID"
			Me.schedulerStorage1.Resources.Mappings.Caption = "Model"
		End Sub
	End Class
End Namespace