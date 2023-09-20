'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
Imports System
Imports System.ComponentModel
Imports System.Data.EntityClient
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports System.Linq
Imports System.Runtime.Serialization
Imports System.Xml.Serialization

<Assembly:System.Data.Objects.DataClasses.EdmSchemaAttribute()>
Namespace SchedulerEntityFramework

'#Region "Contexts"
    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    Public Partial Class CarsXtraSchedulingEntities
        Inherits System.Data.Objects.ObjectContext

'#Region "Constructors"
        ''' <summary>
        ''' Initializes a new CarsXtraSchedulingEntities object using the connection string found in the 'CarsXtraSchedulingEntities' section of the application configuration file.
        ''' </summary>
        Public Sub New()
            MyBase.New("name=CarsXtraSchedulingEntities", "CarsXtraSchedulingEntities")
            Me.ContextOptions.LazyLoadingEnabled = True
            Me.OnContextCreated()
        End Sub

        ''' <summary>
        ''' Initialize a new CarsXtraSchedulingEntities object.
        ''' </summary>
        Public Sub New(ByVal connectionString As String)
            MyBase.New(connectionString, "CarsXtraSchedulingEntities")
            Me.ContextOptions.LazyLoadingEnabled = True
            Me.OnContextCreated()
        End Sub

        ''' <summary>
        ''' Initialize a new CarsXtraSchedulingEntities object.
        ''' </summary>
        Public Sub New(ByVal connection As System.Data.EntityClient.EntityConnection)
            MyBase.New(connection, "CarsXtraSchedulingEntities")
            Me.ContextOptions.LazyLoadingEnabled = True
            Me.OnContextCreated()
        End Sub

'#End Region
'#Region "Partial Methods"
        Partial Private Sub OnContextCreated()
        End Sub

'#End Region
'#Region "ObjectSet Properties"
        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        Public ReadOnly Property Cars As ObjectSet(Of SchedulerEntityFramework.Car)
            Get
                If(Me._Cars Is Nothing) Then
                    Me._Cars = Me.CreateObjectSet(Of SchedulerEntityFramework.Car)("Cars")
                End If

                Return Me._Cars
            End Get
        End Property

        Private _Cars As System.Data.Objects.ObjectSet(Of SchedulerEntityFramework.Car)

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        Public ReadOnly Property CarSchedulings As ObjectSet(Of SchedulerEntityFramework.CarScheduling)
            Get
                If(Me._CarSchedulings Is Nothing) Then
                    Me._CarSchedulings = Me.CreateObjectSet(Of SchedulerEntityFramework.CarScheduling)("CarSchedulings")
                End If

                Return Me._CarSchedulings
            End Get
        End Property

        Private _CarSchedulings As System.Data.Objects.ObjectSet(Of SchedulerEntityFramework.CarScheduling)

'#End Region
'#Region "AddTo Methods"
        ''' <summary>
        ''' Deprecated Method for adding a new object to the Cars EntitySet. Consider using the .Add method of the associated ObjectSet&lt; T&gt;  property instead.
        ''' </summary>
        Public Sub AddToCars(ByVal car As SchedulerEntityFramework.Car)
            Me.AddObject("Cars", car)
        End Sub

        ''' <summary>
        ''' Deprecated Method for adding a new object to the CarSchedulings EntitySet. Consider using the .Add method of the associated ObjectSet&lt; T&gt;  property instead.
        ''' </summary>
        Public Sub AddToCarSchedulings(ByVal carScheduling As SchedulerEntityFramework.CarScheduling)
            Me.AddObject("CarSchedulings", carScheduling)
        End Sub
'#End Region
    End Class

'#End Region
'#Region "Entities"
    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName:="CarsXtraSchedulingModel", Name:="Car")>
    <System.SerializableAttribute()>
    <System.Runtime.Serialization.DataContractAttribute(IsReference:=True)>
    Public Partial Class Car
        Inherits System.Data.Objects.DataClasses.EntityObject

'#Region "Factory Method"
        ''' <summary>
        ''' Create a new Car object.
        ''' </summary>
        ''' <param name="id">Initial value of the ID property.</param>
        Public Shared Function CreateCar(ByVal id As Global.System.Int32) As Car
            Dim car As SchedulerEntityFramework.Car = New SchedulerEntityFramework.Car()
            car.ID = id
            Return car
        End Function

'#End Region
'#Region "Primitive Properties"
        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=True, IsNullable:=False)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID As Global.System.Int32
            Get
                Return Me._ID
            End Get

            Set(ByVal value As Global.System.Int32)
                If Me._ID <> value Then
                    Me.OnIDChanging(value)
                    Me.ReportPropertyChanging("ID")
                    Me._ID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
                    Me.ReportPropertyChanged("ID")
                    Me.OnIDChanged()
                End If
            End Set
        End Property

        Private _ID As Global.System.Int32

        Partial Private Sub OnIDChanging(ByVal value As Global.System.Int32)
        End Sub

        Partial Private Sub OnIDChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Trademark As Global.System.[String]
            Get
                Return Me._Trademark
            End Get

            Set(ByVal value As Global.System.[String])
                Me.OnTrademarkChanging(value)
                Me.ReportPropertyChanging("Trademark")
                Me._Trademark = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
                Me.ReportPropertyChanged("Trademark")
                Me.OnTrademarkChanged()
            End Set
        End Property

        Private _Trademark As Global.System.[String]

        Partial Private Sub OnTrademarkChanging(ByVal value As Global.System.[String])
        End Sub

        Partial Private Sub OnTrademarkChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Model As Global.System.[String]
            Get
                Return Me._Model
            End Get

            Set(ByVal value As Global.System.[String])
                Me.OnModelChanging(value)
                Me.ReportPropertyChanging("Model")
                Me._Model = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
                Me.ReportPropertyChanged("Model")
                Me.OnModelChanged()
            End Set
        End Property

        Private _Model As Global.System.[String]

        Partial Private Sub OnModelChanging(ByVal value As Global.System.[String])
        End Sub

        Partial Private Sub OnModelChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HP As Nullable(Of Global.System.Int16)
            Get
                Return Me._HP
            End Get

            Set(ByVal value As Nullable(Of Global.System.Int16))
                Me.OnHPChanging(value)
                Me.ReportPropertyChanging("HP")
                Me._HP = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
                Me.ReportPropertyChanged("HP")
                Me.OnHPChanged()
            End Set
        End Property

        Private _HP As System.Nullable(Of Global.System.Int16)

        Partial Private Sub OnHPChanging(ByVal value As System.Nullable(Of Global.System.Int16))
        End Sub

        Partial Private Sub OnHPChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Liter As Nullable(Of Global.System.[Double])
            Get
                Return Me._Liter
            End Get

            Set(ByVal value As Nullable(Of Global.System.[Double]))
                Me.OnLiterChanging(value)
                Me.ReportPropertyChanging("Liter")
                Me._Liter = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
                Me.ReportPropertyChanged("Liter")
                Me.OnLiterChanged()
            End Set
        End Property

        Private _Liter As System.Nullable(Of Global.System.[Double])

        Partial Private Sub OnLiterChanging(ByVal value As System.Nullable(Of Global.System.[Double]))
        End Sub

        Partial Private Sub OnLiterChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Cyl As Nullable(Of Global.System.Int16)
            Get
                Return Me._Cyl
            End Get

            Set(ByVal value As Nullable(Of Global.System.Int16))
                Me.OnCylChanging(value)
                Me.ReportPropertyChanging("Cyl")
                Me._Cyl = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
                Me.ReportPropertyChanged("Cyl")
                Me.OnCylChanged()
            End Set
        End Property

        Private _Cyl As System.Nullable(Of Global.System.Int16)

        Partial Private Sub OnCylChanging(ByVal value As System.Nullable(Of Global.System.Int16))
        End Sub

        Partial Private Sub OnCylChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TransmissSpeedCount As Nullable(Of Global.System.Int16)
            Get
                Return Me._TransmissSpeedCount
            End Get

            Set(ByVal value As Nullable(Of Global.System.Int16))
                Me.OnTransmissSpeedCountChanging(value)
                Me.ReportPropertyChanging("TransmissSpeedCount")
                Me._TransmissSpeedCount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
                Me.ReportPropertyChanged("TransmissSpeedCount")
                Me.OnTransmissSpeedCountChanged()
            End Set
        End Property

        Private _TransmissSpeedCount As System.Nullable(Of Global.System.Int16)

        Partial Private Sub OnTransmissSpeedCountChanging(ByVal value As System.Nullable(Of Global.System.Int16))
        End Sub

        Partial Private Sub OnTransmissSpeedCountChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TransmissAutomatic As Global.System.[String]
            Get
                Return Me._TransmissAutomatic
            End Get

            Set(ByVal value As Global.System.[String])
                Me.OnTransmissAutomaticChanging(value)
                Me.ReportPropertyChanging("TransmissAutomatic")
                Me._TransmissAutomatic = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
                Me.ReportPropertyChanged("TransmissAutomatic")
                Me.OnTransmissAutomaticChanged()
            End Set
        End Property

        Private _TransmissAutomatic As Global.System.[String]

        Partial Private Sub OnTransmissAutomaticChanging(ByVal value As Global.System.[String])
        End Sub

        Partial Private Sub OnTransmissAutomaticChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MPG_City As Nullable(Of Global.System.Int16)
            Get
                Return Me._MPG_City
            End Get

            Set(ByVal value As Nullable(Of Global.System.Int16))
                Me.OnMPG_CityChanging(value)
                Me.ReportPropertyChanging("MPG_City")
                Me._MPG_City = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
                Me.ReportPropertyChanged("MPG_City")
                Me.OnMPG_CityChanged()
            End Set
        End Property

        Private _MPG_City As System.Nullable(Of Global.System.Int16)

        Partial Private Sub OnMPG_CityChanging(ByVal value As System.Nullable(Of Global.System.Int16))
        End Sub

        Partial Private Sub OnMPG_CityChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MPG_Highway As Nullable(Of Global.System.Int16)
            Get
                Return Me._MPG_Highway
            End Get

            Set(ByVal value As Nullable(Of Global.System.Int16))
                Me.OnMPG_HighwayChanging(value)
                Me.ReportPropertyChanging("MPG_Highway")
                Me._MPG_Highway = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
                Me.ReportPropertyChanged("MPG_Highway")
                Me.OnMPG_HighwayChanged()
            End Set
        End Property

        Private _MPG_Highway As System.Nullable(Of Global.System.Int16)

        Partial Private Sub OnMPG_HighwayChanging(ByVal value As System.Nullable(Of Global.System.Int16))
        End Sub

        Partial Private Sub OnMPG_HighwayChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Category As Global.System.[String]
            Get
                Return Me._Category
            End Get

            Set(ByVal value As Global.System.[String])
                Me.OnCategoryChanging(value)
                Me.ReportPropertyChanging("Category")
                Me._Category = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
                Me.ReportPropertyChanged("Category")
                Me.OnCategoryChanged()
            End Set
        End Property

        Private _Category As Global.System.[String]

        Partial Private Sub OnCategoryChanging(ByVal value As Global.System.[String])
        End Sub

        Partial Private Sub OnCategoryChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Description As Global.System.[String]
            Get
                Return Me._Description
            End Get

            Set(ByVal value As Global.System.[String])
                Me.OnDescriptionChanging(value)
                Me.ReportPropertyChanging("Description")
                Me._Description = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
                Me.ReportPropertyChanged("Description")
                Me.OnDescriptionChanged()
            End Set
        End Property

        Private _Description As Global.System.[String]

        Partial Private Sub OnDescriptionChanging(ByVal value As Global.System.[String])
        End Sub

        Partial Private Sub OnDescriptionChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Hyperlink As Global.System.[String]
            Get
                Return Me._Hyperlink
            End Get

            Set(ByVal value As Global.System.[String])
                Me.OnHyperlinkChanging(value)
                Me.ReportPropertyChanging("Hyperlink")
                Me._Hyperlink = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
                Me.ReportPropertyChanged("Hyperlink")
                Me.OnHyperlinkChanged()
            End Set
        End Property

        Private _Hyperlink As Global.System.[String]

        Partial Private Sub OnHyperlinkChanging(ByVal value As Global.System.[String])
        End Sub

        Partial Private Sub OnHyperlinkChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Picture As Global.System.[Byte]()
            Get
                Return System.Data.Objects.DataClasses.StructuralObject.GetValidValue(Me._Picture)
            End Get

            Set(ByVal value As Global.System.[Byte]())
                Me.OnPictureChanging(value)
                Me.ReportPropertyChanging("Picture")
                Me._Picture = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
                Me.ReportPropertyChanged("Picture")
                Me.OnPictureChanged()
            End Set
        End Property

        Private _Picture As Global.System.[Byte]()

        Partial Private Sub OnPictureChanging(ByVal value As Global.System.[Byte]())
        End Sub

        Partial Private Sub OnPictureChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Price As Nullable(Of Global.System.[Decimal])
            Get
                Return Me._Price
            End Get

            Set(ByVal value As Nullable(Of Global.System.[Decimal]))
                Me.OnPriceChanging(value)
                Me.ReportPropertyChanging("Price")
                Me._Price = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
                Me.ReportPropertyChanged("Price")
                Me.OnPriceChanged()
            End Set
        End Property

        Private _Price As System.Nullable(Of Global.System.[Decimal])

        Partial Private Sub OnPriceChanging(ByVal value As System.Nullable(Of Global.System.[Decimal]))
        End Sub

        Partial Private Sub OnPriceChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RtfContent As Global.System.[String]
            Get
                Return Me._RtfContent
            End Get

            Set(ByVal value As Global.System.[String])
                Me.OnRtfContentChanging(value)
                Me.ReportPropertyChanging("RtfContent")
                Me._RtfContent = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
                Me.ReportPropertyChanged("RtfContent")
                Me.OnRtfContentChanged()
            End Set
        End Property

        Private _RtfContent As Global.System.[String]

        Partial Private Sub OnRtfContentChanging(ByVal value As Global.System.[String])
        End Sub

        Partial Private Sub OnRtfContentChanged()
        End Sub
'#End Region
    End Class

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName:="CarsXtraSchedulingModel", Name:="CarScheduling")>
    <System.SerializableAttribute()>
    <System.Runtime.Serialization.DataContractAttribute(IsReference:=True)>
    Public Partial Class CarScheduling
        Inherits System.Data.Objects.DataClasses.EntityObject

'#Region "Factory Method"
        ''' <summary>
        ''' Create a new CarScheduling object.
        ''' </summary>
        ''' <param name="id">Initial value of the ID property.</param>
        ''' <param name="allDay">Initial value of the AllDay property.</param>
        Public Shared Function CreateCarScheduling(ByVal id As Global.System.Int32, ByVal allDay As Global.System.[Boolean]) As CarScheduling
            Dim carScheduling As SchedulerEntityFramework.CarScheduling = New SchedulerEntityFramework.CarScheduling()
            carScheduling.ID = id
            carScheduling.AllDay = allDay
            Return carScheduling
        End Function

'#End Region
'#Region "Primitive Properties"
        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=True, IsNullable:=False)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID As Global.System.Int32
            Get
                Return Me._ID
            End Get

            Set(ByVal value As Global.System.Int32)
                If Me._ID <> value Then
                    Me.OnIDChanging(value)
                    Me.ReportPropertyChanging("ID")
                    Me._ID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
                    Me.ReportPropertyChanged("ID")
                    Me.OnIDChanged()
                End If
            End Set
        End Property

        Private _ID As Global.System.Int32

        Partial Private Sub OnIDChanging(ByVal value As Global.System.Int32)
        End Sub

        Partial Private Sub OnIDChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CarId As Global.System.[String]
            Get
                Return Me._CarId
            End Get

            Set(ByVal value As Global.System.[String])
                Me.OnCarIdChanging(value)
                Me.ReportPropertyChanging("CarId")
                Me._CarId = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
                Me.ReportPropertyChanged("CarId")
                Me.OnCarIdChanged()
            End Set
        End Property

        Private _CarId As Global.System.[String]

        Partial Private Sub OnCarIdChanging(ByVal value As Global.System.[String])
        End Sub

        Partial Private Sub OnCarIdChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property UserId As Nullable(Of Global.System.Int32)
            Get
                Return Me._UserId
            End Get

            Set(ByVal value As Nullable(Of Global.System.Int32))
                Me.OnUserIdChanging(value)
                Me.ReportPropertyChanging("UserId")
                Me._UserId = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
                Me.ReportPropertyChanged("UserId")
                Me.OnUserIdChanged()
            End Set
        End Property

        Private _UserId As System.Nullable(Of Global.System.Int32)

        Partial Private Sub OnUserIdChanging(ByVal value As System.Nullable(Of Global.System.Int32))
        End Sub

        Partial Private Sub OnUserIdChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Status As Nullable(Of Global.System.Int32)
            Get
                Return Me._Status
            End Get

            Set(ByVal value As Nullable(Of Global.System.Int32))
                Me.OnStatusChanging(value)
                Me.ReportPropertyChanging("Status")
                Me._Status = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
                Me.ReportPropertyChanged("Status")
                Me.OnStatusChanged()
            End Set
        End Property

        Private _Status As System.Nullable(Of Global.System.Int32)

        Partial Private Sub OnStatusChanging(ByVal value As System.Nullable(Of Global.System.Int32))
        End Sub

        Partial Private Sub OnStatusChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Subject As Global.System.[String]
            Get
                Return Me._Subject
            End Get

            Set(ByVal value As Global.System.[String])
                Me.OnSubjectChanging(value)
                Me.ReportPropertyChanging("Subject")
                Me._Subject = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
                Me.ReportPropertyChanged("Subject")
                Me.OnSubjectChanged()
            End Set
        End Property

        Private _Subject As Global.System.[String]

        Partial Private Sub OnSubjectChanging(ByVal value As Global.System.[String])
        End Sub

        Partial Private Sub OnSubjectChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Description As Global.System.[String]
            Get
                Return Me._Description
            End Get

            Set(ByVal value As Global.System.[String])
                Me.OnDescriptionChanging(value)
                Me.ReportPropertyChanging("Description")
                Me._Description = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
                Me.ReportPropertyChanged("Description")
                Me.OnDescriptionChanged()
            End Set
        End Property

        Private _Description As Global.System.[String]

        Partial Private Sub OnDescriptionChanging(ByVal value As Global.System.[String])
        End Sub

        Partial Private Sub OnDescriptionChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Label As Nullable(Of Global.System.Int32)
            Get
                Return Me._Label
            End Get

            Set(ByVal value As Nullable(Of Global.System.Int32))
                Me.OnLabelChanging(value)
                Me.ReportPropertyChanging("Label")
                Me._Label = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
                Me.ReportPropertyChanged("Label")
                Me.OnLabelChanged()
            End Set
        End Property

        Private _Label As System.Nullable(Of Global.System.Int32)

        Partial Private Sub OnLabelChanging(ByVal value As System.Nullable(Of Global.System.Int32))
        End Sub

        Partial Private Sub OnLabelChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartTime As Nullable(Of Global.System.DateTime)
            Get
                Return Me._StartTime
            End Get

            Set(ByVal value As Nullable(Of Global.System.DateTime))
                Me.OnStartTimeChanging(value)
                Me.ReportPropertyChanging("StartTime")
                Me._StartTime = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
                Me.ReportPropertyChanged("StartTime")
                Me.OnStartTimeChanged()
            End Set
        End Property

        Private _StartTime As System.Nullable(Of Global.System.DateTime)

        Partial Private Sub OnStartTimeChanging(ByVal value As System.Nullable(Of Global.System.DateTime))
        End Sub

        Partial Private Sub OnStartTimeChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EndTime As Nullable(Of Global.System.DateTime)
            Get
                Return Me._EndTime
            End Get

            Set(ByVal value As Nullable(Of Global.System.DateTime))
                Me.OnEndTimeChanging(value)
                Me.ReportPropertyChanging("EndTime")
                Me._EndTime = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
                Me.ReportPropertyChanged("EndTime")
                Me.OnEndTimeChanged()
            End Set
        End Property

        Private _EndTime As System.Nullable(Of Global.System.DateTime)

        Partial Private Sub OnEndTimeChanging(ByVal value As System.Nullable(Of Global.System.DateTime))
        End Sub

        Partial Private Sub OnEndTimeChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Location As Global.System.[String]
            Get
                Return Me._Location
            End Get

            Set(ByVal value As Global.System.[String])
                Me.OnLocationChanging(value)
                Me.ReportPropertyChanging("Location")
                Me._Location = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
                Me.ReportPropertyChanged("Location")
                Me.OnLocationChanged()
            End Set
        End Property

        Private _Location As Global.System.[String]

        Partial Private Sub OnLocationChanging(ByVal value As Global.System.[String])
        End Sub

        Partial Private Sub OnLocationChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AllDay As Global.System.[Boolean]
            Get
                Return Me._AllDay
            End Get

            Set(ByVal value As Global.System.[Boolean])
                Me.OnAllDayChanging(value)
                Me.ReportPropertyChanging("AllDay")
                Me._AllDay = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
                Me.ReportPropertyChanged("AllDay")
                Me.OnAllDayChanged()
            End Set
        End Property

        Private _AllDay As Global.System.[Boolean]

        Partial Private Sub OnAllDayChanging(ByVal value As Global.System.[Boolean])
        End Sub

        Partial Private Sub OnAllDayChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EventType As Nullable(Of Global.System.Int32)
            Get
                Return Me._EventType
            End Get

            Set(ByVal value As Nullable(Of Global.System.Int32))
                Me.OnEventTypeChanging(value)
                Me.ReportPropertyChanging("EventType")
                Me._EventType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
                Me.ReportPropertyChanged("EventType")
                Me.OnEventTypeChanged()
            End Set
        End Property

        Private _EventType As System.Nullable(Of Global.System.Int32)

        Partial Private Sub OnEventTypeChanging(ByVal value As System.Nullable(Of Global.System.Int32))
        End Sub

        Partial Private Sub OnEventTypeChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RecurrenceInfo As Global.System.[String]
            Get
                Return Me._RecurrenceInfo
            End Get

            Set(ByVal value As Global.System.[String])
                Me.OnRecurrenceInfoChanging(value)
                Me.ReportPropertyChanging("RecurrenceInfo")
                Me._RecurrenceInfo = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
                Me.ReportPropertyChanged("RecurrenceInfo")
                Me.OnRecurrenceInfoChanged()
            End Set
        End Property

        Private _RecurrenceInfo As Global.System.[String]

        Partial Private Sub OnRecurrenceInfoChanging(ByVal value As Global.System.[String])
        End Sub

        Partial Private Sub OnRecurrenceInfoChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ReminderInfo As Global.System.[String]
            Get
                Return Me._ReminderInfo
            End Get

            Set(ByVal value As Global.System.[String])
                Me.OnReminderInfoChanging(value)
                Me.ReportPropertyChanging("ReminderInfo")
                Me._ReminderInfo = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
                Me.ReportPropertyChanged("ReminderInfo")
                Me.OnReminderInfoChanged()
            End Set
        End Property

        Private _ReminderInfo As Global.System.[String]

        Partial Private Sub OnReminderInfoChanging(ByVal value As Global.System.[String])
        End Sub

        Partial Private Sub OnReminderInfoChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Price As Nullable(Of Global.System.[Decimal])
            Get
                Return Me._Price
            End Get

            Set(ByVal value As Nullable(Of Global.System.[Decimal]))
                Me.OnPriceChanging(value)
                Me.ReportPropertyChanging("Price")
                Me._Price = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
                Me.ReportPropertyChanged("Price")
                Me.OnPriceChanged()
            End Set
        End Property

        Private _Price As System.Nullable(Of Global.System.[Decimal])

        Partial Private Sub OnPriceChanging(ByVal value As System.Nullable(Of Global.System.[Decimal]))
        End Sub

        Partial Private Sub OnPriceChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ContactInfo As Global.System.[String]
            Get
                Return Me._ContactInfo
            End Get

            Set(ByVal value As Global.System.[String])
                Me.OnContactInfoChanging(value)
                Me.ReportPropertyChanging("ContactInfo")
                Me._ContactInfo = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
                Me.ReportPropertyChanged("ContactInfo")
                Me.OnContactInfoChanged()
            End Set
        End Property

        Private _ContactInfo As Global.System.[String]

        Partial Private Sub OnContactInfoChanging(ByVal value As Global.System.[String])
        End Sub

        Partial Private Sub OnContactInfoChanged()
        End Sub
'#End Region
    End Class
'#End Region
End Namespace
