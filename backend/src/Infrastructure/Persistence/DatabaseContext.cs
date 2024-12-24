using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class DatabaseContext : DbContext
{
    public virtual DbSet<CsCall> CsCalls { get; set; }

    public virtual DbSet<CsCustomer> CsCustomers { get; set; }

    public virtual DbSet<CsVisit> CsVisits { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<GovernCity> GovernCities { get; set; }

    public virtual DbSet<Governorate> Governorates { get; set; }


    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AS");

        modelBuilder.Entity<CsCall>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.EName)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("eName");

            entity.HasOne(d => d.Customer).WithMany()
                .HasPrincipalKey(p => p.CustomerId)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CsCalls_CsCustomers");
        });

        modelBuilder.Entity<CsCustomer>(entity =>
        {
            entity.HasKey(e => e.Mobile)
                .HasName("PK_CsRequest")
                .HasFillFactor(90);

            entity.HasIndex(e => e.CustomerId, "IX_CsCustomers")
                .IsUnique()
                .HasFillFactor(90);

            entity.HasIndex(e => e.Home, "IX_CsCustomers_1").HasFillFactor(90);

            entity.Property(e => e.Mobile)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.AName)
                .HasMaxLength(50)
                .HasColumnName("aName");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasDefaultValue("");
            entity.Property(e => e.Center)
                .HasMaxLength(30)
                .HasDefaultValue("");
            entity.Property(e => e.CityId)
                .HasDefaultValue((short)1)
                .HasColumnName("CityID");
            entity.Property(e => e.CustomerId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CustomerID");
            entity.Property(e => e.Home)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Model)
                .HasMaxLength(60)
                .HasDefaultValue("");
            entity.Property(e => e.Remark)
                .HasMaxLength(60)
                .HasDefaultValue("");

            entity.HasOne(d => d.City).WithMany(p => p.CsCustomers)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CsCustomers_GovernCity1");
        });

        modelBuilder.Entity<CsVisit>(entity =>
        {
            entity.HasKey(e => e.VisitId)
                .HasName("PK_CsRequest_1")
                .HasFillFactor(90);

            entity.ToTable("CsVisit");

            entity.HasIndex(e => e.VisitDate, "IX_CsRequest").HasFillFactor(90);

            entity.HasIndex(e => e.DefectId, "IX_CsVisit").HasFillFactor(90);

            entity.Property(e => e.VisitId)
                .ValueGeneratedNever()
                .HasColumnName("VisitID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DefectId).HasColumnName("DefectID");
            entity.Property(e => e.RegionId)
                .HasDefaultValue((byte)1)
                .HasColumnName("RegionID");
            entity.Property(e => e.SalesId).HasColumnName("SalesID");
            entity.Property(e => e.VisitId1)
                .ValueGeneratedOnAdd()
                .HasColumnName("Visit_ID");
            entity.Property(e => e.VisitWord).HasMaxLength(80);
            entity.Property(e => e.WorkDone)
                .HasMaxLength(100)
                .HasDefaultValue("");

            entity.HasOne(d => d.Customer).WithMany(p => p.CsVisits)
                .HasPrincipalKey(p => p.CustomerId)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CsVisit_CsCustomers");

            entity.HasOne(d => d.DataEntryNavigation).WithMany(p => p.CsVisits)
                .HasForeignKey(d => d.DataEntry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CsVisit_Employee");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeCode)
                .HasName("PK_Employee_1")
                .IsClustered(false)
                .HasFillFactor(90);

            entity.ToTable("Employee");

            entity.HasIndex(e => e.CostCode, "IX_Employee")
                .IsClustered()
                .HasFillFactor(90);

            entity.HasIndex(e => e.AName, "IX_Employee_1").HasFillFactor(90);

            entity.HasIndex(e => e.LocationCode, "IX_Employee_2").HasFillFactor(90);

            entity.HasIndex(e => e.LocationCode, "IX_Employee_3");

            entity.Property(e => e.AName)
                .HasMaxLength(50)
                .HasColumnName("aName");
            entity.Property(e => e.AbsenceShow).HasDefaultValue(true);
            entity.Property(e => e.Address1)
                .HasMaxLength(80)
                .HasDefaultValue("");
            entity.Property(e => e.Address2)
                .HasMaxLength(60)
                .HasDefaultValue("");
            entity.Property(e => e.Attendance).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.Attendance2).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.BankAccount)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.BankAccount2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.BankId).HasColumnName("BankID");
            entity.Property(e => e.BirthDate).HasDefaultValue(new DateOnly(2010, 1, 1));
            entity.Property(e => e.BranchNo)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.CarId).HasColumnName("CarID");
            entity.Property(e => e.CardName)
                .HasMaxLength(25)
                .HasDefaultValue("");
            entity.Property(e => e.CardNo)
                .HasMaxLength(25)
                .HasDefaultValue("");
            entity.Property(e => e.CardNo2)
                .HasMaxLength(25)
                .HasDefaultValue("");
            entity.Property(e => e.CatId)
                .HasDefaultValue((byte)1)
                .HasColumnName("CatID");
            entity.Property(e => e.ClassId)
                .HasDefaultValue((byte)1)
                .HasColumnName("ClassID");
            entity.Property(e => e.CostCode).HasDefaultValue(1);
            entity.Property(e => e.CountryId)
                .HasDefaultValue((byte)1)
                .HasColumnName("CountryID");
            entity.Property(e => e.CrncyId)
                .HasDefaultValue((byte)1)
                .HasColumnName("CrncyID");
            entity.Property(e => e.DailyRate).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.DaysOffCode).HasDefaultValue((byte)1);
            entity.Property(e => e.DelayYes).HasDefaultValue(true);
            entity.Property(e => e.DirectId)
                .HasDefaultValue((byte)1)
                .HasColumnName("DirectID");
            entity.Property(e => e.EName)
                .HasMaxLength(50)
                .HasColumnName("eName");
            entity.Property(e => e.EducationId).HasColumnName("EducationID");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(40)
                .HasDefaultValue("");
            entity.Property(e => e.GSalary).HasColumnName("gSalary");
            entity.Property(e => e.GoverId)
                .HasDefaultValue((byte)1)
                .HasColumnName("GoverID");
            entity.Property(e => e.GovernId)
                .HasDefaultValue((byte)1)
                .HasColumnName("GovernID");
            entity.Property(e => e.GradYear)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.GroupCode1).HasDefaultValue((byte)1);
            entity.Property(e => e.GroupCode2).HasDefaultValue((byte)1);
            entity.Property(e => e.GroupCode3).HasDefaultValue((byte)1);
            entity.Property(e => e.HRateType)
                .HasDefaultValue((byte)1)
                .HasColumnName("hRateType");
            entity.Property(e => e.HireDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.HrGroup).HasDefaultValue((byte)1);
            entity.Property(e => e.IDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("iDate");
            entity.Property(e => e.Idno)
                .HasMaxLength(30)
                .HasDefaultValue("")
                .HasColumnName("IDNo");
            entity.Property(e => e.Idvalid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("IDvalid");
            entity.Property(e => e.Iid)
                //.ValueGeneratedOnAdd()
                .HasColumnName("IID");
            entity.Property(e => e.InsureBasic).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.InsureShamel).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.JobCode).HasDefaultValue((short)1);
            entity.Property(e => e.LeaveDate).HasDefaultValue(new DateOnly(5555, 12, 31));
            entity.Property(e => e.LocationCode).HasDefaultValue((byte)1);
            entity.Property(e => e.Male)
                .HasDefaultValue(true)
                .HasColumnName("male");
            entity.Property(e => e.MaritalId)
                .HasDefaultValue((byte)1)
                .HasColumnName("MaritalID");
            entity.Property(e => e.MealCode).HasDefaultValue((byte)1);
            entity.Property(e => e.MedicalCard)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.MedicalInsure).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.MilitaryId)
                .HasDefaultValue((byte)1)
                .HasColumnName("MilitaryID");
            entity.Property(e => e.MissionId)
                .HasDefaultValue((byte)1)
                .HasColumnName("MissionID");
            entity.Property(e => e.MotherName)
                .HasMaxLength(60)
                .HasDefaultValue("");
            entity.Property(e => e.MyPic).HasColumnType("image");
            entity.Property(e => e.OverTimeYes).HasDefaultValue(true);
            entity.Property(e => e.PayId)
                .HasDefaultValue((byte)1)
                .HasColumnName("PayID");
            entity.Property(e => e.PermYes).HasDefaultValue(true);
            entity.Property(e => e.PermanentId)
                .HasDefaultValue((byte)1)
                .HasColumnName("PermanentID");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(60)
                .HasDefaultValue("");
            entity.Property(e => e.PlantCode).HasDefaultValue((short)1);
            entity.Property(e => e.PostVacation).HasDefaultValue(true);
            entity.Property(e => e.Privilege).HasColumnName("privilege");
            entity.Property(e => e.ProfitId)
                .HasDefaultValue((byte)1)
                .HasColumnName("ProfitID");
            entity.Property(e => e.RealStart).HasDefaultValue(true);
            entity.Property(e => e.ReligionId)
                .HasDefaultValue((byte)1)
                .HasColumnName("ReligionID");
            entity.Property(e => e.SPassword)
                .HasMaxLength(4)
                .HasDefaultValue("")
                .HasColumnName("sPassword");
            entity.Property(e => e.Salary).HasDefaultValue((byte)1);
            entity.Property(e => e.SecurityGroup)
                .HasMaxLength(50)
                .HasDefaultValue("P1,H1");
            entity.Property(e => e.SevenDaysPlus).HasDefaultValue(true);
            entity.Property(e => e.ShiftNo).HasDefaultValue((byte)1);
            entity.Property(e => e.Specialist)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.StaffId)
                .HasDefaultValue((byte)1)
                .HasColumnName("StaffID");
            entity.Property(e => e.Taxbale)
                .HasDefaultValue(true)
                .HasColumnName("taxbale");
            entity.Property(e => e.TimeSheetYes).HasDefaultValue(true);
            entity.Property(e => e.UniversityGrad)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.WTypeCode)
                .HasDefaultValue((byte)1)
                .HasColumnName("wTypeCode");
            entity.Property(e => e.WorkNo)
                .HasMaxLength(15)
                .HasDefaultValue("");
            entity.Property(e => e.WorkNoReply)
                .HasMaxLength(15)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<GovernCity>(entity =>
        {
            entity.HasKey(e => e.CityId).HasFillFactor(90);

            entity.ToTable("GovernCity");

            entity.Property(e => e.CityId)
                .ValueGeneratedNever()
                .HasColumnName("CityID");
            entity.Property(e => e.AName)
                .HasMaxLength(30)
                .HasColumnName("aName");
            entity.Property(e => e.GovernId).HasColumnName("GovernID");

            entity.HasOne(d => d.Govern).WithMany(p => p.GovernCities)
                .HasForeignKey(d => d.GovernId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GovernCity_Governorates");
        });

        modelBuilder.Entity<Governorate>(entity =>
        {
            entity.HasKey(e => e.GovernId)
                .HasName("PK_Governrates")
                .HasFillFactor(90);

            entity.Property(e => e.GovernId)
                .ValueGeneratedNever()
                .HasColumnName("GovernID");
            entity.Property(e => e.AName)
                .HasMaxLength(25)
                .HasColumnName("aName");
            entity.Property(e => e.Capital)
                .HasMaxLength(25)
                .HasDefaultValue("");
            entity.Property(e => e.GoverId).HasColumnName("GoverID");
            entity.Property(e => e.RegionId)
                .HasDefaultValue((byte)1)
                .HasColumnName("RegionID");
        });

    }
}