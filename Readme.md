<!-- default file list -->
*Files to look at*:

* [Car.cs](./CS/Car.cs) (VB: [CarScheduling.vb](./VB/CarScheduling.vb))
* [CarScheduling.cs](./CS/CarScheduling.cs) (VB: [CarScheduling.vb](./VB/CarScheduling.vb))
* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
* [Model1.Context.cs](./CS/Model1.Context.cs) (VB: [Model1.Context.vb](./VB/Model1.Context.vb))
* [Model1.cs](./CS/Model1.cs) (VB: [Model1.vb](./VB/Model1.vb))
* [Program.cs](./CS/Program.cs) (VB: [Program.vb](./VB/Program.vb))
<!-- default file list end -->
# How to handle the FetchAppointments event when the scheduler is used with Entity Framework


<p>The <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerSchedulerStorageBase_FetchAppointmentstopic">SchedulerStorageBase.FetchAppointments Event</a> allows you to limit the number of appointments fetched from the data source. This can be useful when working with a large amount of data, and only a small part of it needs to be loaded at one time. </p>
<p><br>Please pay special attention to managing recurring appointments. A recurring appointment series is never stored in the underlying data source. The data source only contains records for the pattern, and changed and deleted appointments. Once you change or delete any appointment from that series, a new appointment is created with a corresponding <a href="https://documentation.devexpress.com/CoreLibraries/DevExpressXtraSchedulerAppointment_Typetopic.aspx">Appointment.Type</a> - <a href="https://documentation.devexpress.com/CoreLibraries/DevExpressXtraSchedulerAppointmentTypeEnumtopic.aspx">AppointmentType.ChangedOccurrence</a> (value = 3) or <a href="https://documentation.devexpress.com/CoreLibraries/DevExpressXtraSchedulerAppointmentTypeEnumtopic.aspx">AppointmentType.DeletedOccurrence</a> (value = 4 ), and this appointment is stored in the data source as a separate record. <br><br>The SchedulerControl generates recurring series with occurrences based on the pattern's recurring rule and removes deleted and changed occurrences from the chain. However, if the changed occurrence is moved outside of the queryable time range, it is not loaded and the SchedulerControl will <strong>generate an occurrence with the corresponding recurrence index</strong> instead of this (non-loaded) changed occurrence. <br><br>To handle this situation, it is possible to load all changed occurrences despite their Start and End property values or implement two additional <a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument17137">appointment custom fields</a> to store original occurrence's Start and End values. The latter approach is demonstrated in this example.</p>
<p> </p>
<p>Please note that prior to v.15.2, the FetchAppointments event occurs in situations, which do not involve any changes in displayed data ranges. This behavior may result in unhandled exceptions if the event was not properly handled. To solve the problem, we have implemented additional internal criteria that should be met before the event is raised. Starting with v.15.2, the FetchAppointments event fires not as often as it did before and does not fire at all in certain situations. If you experience unwanted side effects due to the newly introduced behavior, set the <a href="https://documentation.devexpress.com/CoreLibraries/DevExpressXtraSchedulerSchedulerStorageBase_EnableSmartFetchtopic.aspx">EnableSmartFetch</a> option to <strong>false</strong> to revert to the former mechanism of raising the FetchAppointments event.<br><br>This example uses the "Database First" Entity Framework approach. To test the project locally, set up the CarsXtraScheduling sample database in your SQL Server instance. This database script is included along with the attached solution. </p>
<p><strong>See Also:</strong></p>
<p> <a href="http://www.entityframeworktutorial.net/create-first-simple-EDM.aspx">Create the First simple Entity Data Model</a></p>

<br/>


