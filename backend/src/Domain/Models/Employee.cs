using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Employee
{
    public int EmployeCode { get; set; }

    public string EName { get; set; } = null!;

    public string AName { get; set; } = null!;

    public byte LocationCode { get; set; }

    public short PlantCode { get; set; }

    public int CostCode { get; set; }

    public short JobCode { get; set; }

    public DateOnly BirthDate { get; set; }

    public DateOnly HireDate { get; set; }

    public DateOnly LeaveDate { get; set; }

    public byte ShiftNo { get; set; }

    public byte DaysOffCode { get; set; }

    public byte WTypeCode { get; set; }

    public byte DirectId { get; set; }

    public byte PermanentId { get; set; }

    public byte StaffId { get; set; }

    public byte ClassId { get; set; }

    public int CarId { get; set; }

    public byte CountryId { get; set; }

    public byte MilitaryId { get; set; }

    public byte EducationTypeCode { get; set; }

    public byte EducationId { get; set; }

    public decimal DailyRate { get; set; }

    public int ShamelEmp { get; set; }

    public int GSalary { get; set; }

    public byte Salary { get; set; }

    public byte MaritalId { get; set; }

    public short InsureValue { get; set; }

    public int BankId { get; set; }

    public string BranchNo { get; set; } = null!;

    public string BankAccount { get; set; } = null!;

    public byte PayGroup { get; set; }

    public string Address1 { get; set; } = null!;

    public string Address2 { get; set; } = null!;

    public string PhoneNo { get; set; } = null!;

    public long InsuranceNo { get; set; }

    public DateOnly? InsureDate { get; set; }

    public DateOnly? InsureEndDate { get; set; }

    public DateOnly? OldHiringDate { get; set; }

    public string Idno { get; set; } = null!;

    public string Idvalid { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string GradYear { get; set; } = null!;

    public string Specialist { get; set; } = null!;

    public string UniversityGrad { get; set; } = null!;

    public int SupervisorCode { get; set; }

    public bool Male { get; set; }

    public bool Confidential { get; set; }

    public bool TimeSheetYes { get; set; }

    public bool OverTimeYes { get; set; }

    public bool AbsenceShow { get; set; }

    public bool RealStart { get; set; }

    public bool DelayYes { get; set; }

    public bool PermYes { get; set; }

    public bool PostVacation { get; set; }

    public bool SendSheetEmail { get; set; }

    public bool SevenDaysPlus { get; set; }

    public decimal Attendance { get; set; }

    public string SecurityGroup { get; set; } = null!;

    public decimal Attendance2 { get; set; }

    public short Privilege { get; set; }

    public string CardNo { get; set; } = null!;

    public string CardNo2 { get; set; } = null!;

    public string CardName { get; set; } = null!;

    public string SPassword { get; set; } = null!;

    public byte MealCode { get; set; }

    public byte GroupCode1 { get; set; }

    public byte GroupCode2 { get; set; }

    public byte GroupCode3 { get; set; }

    public bool Blocked { get; set; }

    public int EmployeCodeOld { get; set; }

    public byte ReligionId { get; set; }

    public bool FixedSalary { get; set; }

    public byte[]? MyPic { get; set; }

    public DateTime IDate { get; set; }

    public bool Buss { get; set; }

    public bool Housing { get; set; }

    public string WorkNo { get; set; } = null!;

    public string WorkNoReply { get; set; } = null!;

    public bool Sign { get; set; }

    public bool Owners { get; set; }

    public decimal MedicalInsure { get; set; }

    public decimal InsureShamel { get; set; }

    public decimal InsureBasic { get; set; }

    public string MedicalCard { get; set; } = null!;

    public DateOnly? MedicalInsureStartDate { get; set; }

    public DateOnly? MedicalInsureEndDate { get; set; }

    public bool Insured { get; set; }

    public byte ProfitId { get; set; }

    public bool CompayPayTax { get; set; }

    public bool CompanyPayInsure { get; set; }

    public byte MedicalType { get; set; }

    public short LifeInsure { get; set; }

    public int Se7y { get; set; }

    public DateOnly? RetireDate { get; set; }

    public short TenYears { get; set; }

    public bool Manager { get; set; }

    public bool Taxbale { get; set; }

    public short FixedLoan { get; set; }

    public short FixedDayRate { get; set; }

    public short ExtraTrans { get; set; }

    public short ExtraOverTime { get; set; }

    public byte GoverId { get; set; }

    public byte GovernId { get; set; }

    public short FixedHourRate { get; set; }

    public DateOnly? BoxDate { get; set; }

    public bool SpecialNational { get; set; }

    public int MobileKey { get; set; }

    public string MotherName { get; set; } = null!;

    public byte PayId { get; set; }

    public byte HRateType { get; set; }

    public bool Stamp { get; set; }

    public int Iid { get; set; }

    public byte CatId { get; set; }

    public byte CrncyId { get; set; }

    public byte MissionId { get; set; }

    public string BankAccount2 { get; set; } = null!;

    public byte HrGroup { get; set; }

    public virtual ICollection<CsVisit> CsVisits { get; set; } = new List<CsVisit>();
}
