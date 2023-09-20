<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128635089/16.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4668)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WinForms Scheduler - Fetch appointments (Entity Framework)

This example handles the [FetchAppointments](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraScheduler.SchedulerStorageBase.FetchAppointments) event to load specific appointments. This can be useful when the Scheduler control is bound to a large set of data and you only need to load a small portion of it at a time.

```csharp
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
```

> **Note**
>
> The example uses the "Database First" Entity Framework approach. To test the project locally, set up the **CarsXtraScheduling** sample database in your SQL Server instance. The database script is included along with the attached solution.


### Recurring Appointments

A recurring appointment series is never stored in the data source. The data source only contains records for pattern and changed/deleted appointments. Once you change or delete an appointment from that series, a new appointment is created with the corresponding [Appointment.Type](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraScheduler.Appointment.Type) (`AppointmentType.ChangedOccurrence` or `AppointmentType.DeletedOccurrence`). This appointment is stored in the data source as a separate record.

The Scheduler Control generates recurring series with occurrences based on a recurring rule of the pattern. The Scheduler Control removes deleted and changed occurrences from the chain. If the changed occurrence is moved outside of the queryable time range, the occurrence is not loaded and the Scheduler Control <strong>generates an occurrence with the corresponding recurrence index</strong> instead of the changed occurrence (which is not loaded).

This example shows how to load all changed occurrences despite their `Start` and `End` property values or implement two [appointment custom fields](https://docs.devexpress.com/WindowsForms/17137/controls-and-libraries/scheduler/data-binding/mappings/custom-fields) to store original occurrence's `Start` and `End` values.

Prior to v.15.2, the `FetchAppointments` event occurs in situations, which do not involve any changes in displayed data ranges. This behavior may result in unhandled exceptions if the event was not properly handled. We have implemented additional internal criteria that should be met before the event is raised. In v.15.2+, the `FetchAppointments` event fires not as often as it did before and does not fire at all in certain cases. If you experience unwanted side effects due to the newly introduced behavior, disable the [EnableSmartFetch<](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraScheduler.SchedulerStorageBase.EnableSmartFetch) option to revert to the former mechanism of raising the `FetchAppointments` event.


## Files to Review

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))


## See Also

* [Creating an Entity Data Model](https://www.entityframeworktutorial.net/entityframework6/create-entity-data-model.aspx)
