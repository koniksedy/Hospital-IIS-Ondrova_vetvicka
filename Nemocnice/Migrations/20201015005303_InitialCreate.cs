using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nemocnice.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressT",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseNumber = table.Column<int>(nullable: false),
                    StreetName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    ZIP = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressT", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "AdminT",
                columns: table => new
                {
                    AdminId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutsorceCompany = table.Column<string>(nullable: false),
                    WorkPhone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminT", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "AllergyT",
                columns: table => new
                {
                    AllergyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergyT", x => x.AllergyId);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosisT",
                columns: table => new
                {
                    DiagnosisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosisT", x => x.DiagnosisId);
                });

            migrationBuilder.CreateTable(
                name: "DoctorT",
                columns: table => new
                {
                    DoctorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ICZ = table.Column<string>(nullable: false),
                    WorkPhone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorT", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "HealthConditionT",
                columns: table => new
                {
                    HealthConditionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Height = table.Column<float>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    LastCheckupDate = table.Column<DateTime>(nullable: false),
                    BloodType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthConditionT", x => x.HealthConditionId);
                });

            migrationBuilder.CreateTable(
                name: "InsureEmpT",
                columns: table => new
                {
                    InsureEmpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceEmployeeId = table.Column<int>(nullable: false),
                    WorkPhone = table.Column<string>(nullable: false),
                    Possition = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsureEmpT", x => x.InsureEmpId);
                });

            migrationBuilder.CreateTable(
                name: "LoginT",
                columns: table => new
                {
                    LoginId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HashPassword = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginT", x => x.LoginId);
                });

            migrationBuilder.CreateTable(
                name: "MedicallBillT",
                columns: table => new
                {
                    MedicallBillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    PersonalNumber = table.Column<string>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    DiagnosisId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicallBillT", x => x.MedicallBillId);
                    table.ForeignKey(
                        name: "FK_MedicallBillT_DiagnosisT_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "DiagnosisT",
                        principalColumn: "DiagnosisId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicallBillT_DoctorT_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "DoctorT",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllegyHealthsT",
                columns: table => new
                {
                    AllergyHealthId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllergyId = table.Column<int>(nullable: true),
                    HealthConditionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllegyHealthsT", x => x.AllergyHealthId);
                    table.ForeignKey(
                        name: "FK_AllegyHealthsT_AllergyT_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "AllergyT",
                        principalColumn: "AllergyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AllegyHealthsT_HealthConditionT_HealthConditionId",
                        column: x => x.HealthConditionId,
                        principalTable: "HealthConditionT",
                        principalColumn: "HealthConditionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientT",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceCompany = table.Column<int>(nullable: false),
                    HomeAddressAddressId = table.Column<int>(nullable: false),
                    HealthConditionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientT", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_PatientT_HealthConditionT_HealthConditionId",
                        column: x => x.HealthConditionId,
                        principalTable: "HealthConditionT",
                        principalColumn: "HealthConditionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientT_AddressT_HomeAddressAddressId",
                        column: x => x.HomeAddressAddressId,
                        principalTable: "AddressT",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleT",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleType = table.Column<string>(nullable: true),
                    AdminId = table.Column<int>(nullable: true),
                    LoginId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleT", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_RoleT_AdminT_AdminId",
                        column: x => x.AdminId,
                        principalTable: "AdminT",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleT_LoginT_LoginId",
                        column: x => x.LoginId,
                        principalTable: "LoginT",
                        principalColumn: "LoginId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserT",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    SocialNumber = table.Column<string>(nullable: false),
                    WorkAddressAddressId = table.Column<int>(nullable: true),
                    DoctorId = table.Column<int>(nullable: true),
                    InsureEmpId = table.Column<int>(nullable: true),
                    AdminId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserT", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserT_AdminT_AdminId",
                        column: x => x.AdminId,
                        principalTable: "AdminT",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserT_DoctorT_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "DoctorT",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserT_InsureEmpT_InsureEmpId",
                        column: x => x.InsureEmpId,
                        principalTable: "InsureEmpT",
                        principalColumn: "InsureEmpId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserT_LoginT_LoginId",
                        column: x => x.LoginId,
                        principalTable: "LoginT",
                        principalColumn: "LoginId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserT_AddressT_WorkAddressAddressId",
                        column: x => x.WorkAddressAddressId,
                        principalTable: "AddressT",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicallActivityPriceT",
                columns: table => new
                {
                    MedicallActivityPriceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    MedicallBillId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicallActivityPriceT", x => x.MedicallActivityPriceId);
                    table.ForeignKey(
                        name: "FK_MedicallActivityPriceT_MedicallBillT_MedicallBillId",
                        column: x => x.MedicallBillId,
                        principalTable: "MedicallBillT",
                        principalColumn: "MedicallBillId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckupTicketT",
                columns: table => new
                {
                    CheckupTicketId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedByDoctorId = table.Column<int>(nullable: true),
                    ToDoctorDoctorId = table.Column<int>(nullable: true),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckupTicketT", x => x.CheckupTicketId);
                    table.ForeignKey(
                        name: "FK_CheckupTicketT_DoctorT_CreatedByDoctorId",
                        column: x => x.CreatedByDoctorId,
                        principalTable: "DoctorT",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckupTicketT_PatientT_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientT",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckupTicketT_DoctorT_ToDoctorDoctorId",
                        column: x => x.ToDoctorDoctorId,
                        principalTable: "DoctorT",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicallReportT",
                columns: table => new
                {
                    MedicallReportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AuthorDoctorId = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicallReportT", x => x.MedicallReportId);
                    table.ForeignKey(
                        name: "FK_MedicallReportT_DoctorT_AuthorDoctorId",
                        column: x => x.AuthorDoctorId,
                        principalTable: "DoctorT",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicallReportT_PatientT_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientT",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientTreatmentLogT",
                columns: table => new
                {
                    PatientTreatmentLogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: false),
                    DiagnosisId = table.Column<int>(nullable: false),
                    StartOfTreatment = table.Column<DateTime>(nullable: false),
                    EndOfTreatment = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTreatmentLogT", x => x.PatientTreatmentLogId);
                    table.ForeignKey(
                        name: "FK_PatientTreatmentLogT_DiagnosisT_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "DiagnosisT",
                        principalColumn: "DiagnosisId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientTreatmentLogT_PatientT_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientT",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosisActivityPricingsT",
                columns: table => new
                {
                    DiagnosisActivityPricingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentDiagnosisDiagnosisId = table.Column<int>(nullable: true),
                    CurrentPricingMedicallActivityPriceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosisActivityPricingsT", x => x.DiagnosisActivityPricingId);
                    table.ForeignKey(
                        name: "FK_DiagnosisActivityPricingsT_DiagnosisT_CurrentDiagnosisDiagnosisId",
                        column: x => x.CurrentDiagnosisDiagnosisId,
                        principalTable: "DiagnosisT",
                        principalColumn: "DiagnosisId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiagnosisActivityPricingsT_MedicallActivityPriceT_CurrentPricingMedicallActivityPriceId",
                        column: x => x.CurrentPricingMedicallActivityPriceId,
                        principalTable: "MedicallActivityPriceT",
                        principalColumn: "MedicallActivityPriceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosisTicketsT",
                columns: table => new
                {
                    DiagnosisTicketId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiagnosisId = table.Column<int>(nullable: true),
                    CheckupTicketId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosisTicketsT", x => x.DiagnosisTicketId);
                    table.ForeignKey(
                        name: "FK_DiagnosisTicketsT_CheckupTicketT_CheckupTicketId",
                        column: x => x.CheckupTicketId,
                        principalTable: "CheckupTicketT",
                        principalColumn: "CheckupTicketId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiagnosisTicketsT_DiagnosisT_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "DiagnosisT",
                        principalColumn: "DiagnosisId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CureProgressT",
                columns: table => new
                {
                    CureProgressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicallReportId = table.Column<int>(nullable: false),
                    DiagnosisId = table.Column<int>(nullable: false),
                    StateOfTreatment = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CureProgressT", x => x.CureProgressId);
                    table.ForeignKey(
                        name: "FK_CureProgressT_DiagnosisT_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "DiagnosisT",
                        principalColumn: "DiagnosisId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CureProgressT_MedicallReportT_MedicallReportId",
                        column: x => x.MedicallReportId,
                        principalTable: "MedicallReportT",
                        principalColumn: "MedicallReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PictureT",
                columns: table => new
                {
                    PictureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentPicture = table.Column<byte[]>(nullable: true),
                    AllergyId = table.Column<int>(nullable: true),
                    CheckupTicketId = table.Column<int>(nullable: true),
                    MedicallReportId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureT", x => x.PictureId);
                    table.ForeignKey(
                        name: "FK_PictureT_AllergyT_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "AllergyT",
                        principalColumn: "AllergyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PictureT_CheckupTicketT_CheckupTicketId",
                        column: x => x.CheckupTicketId,
                        principalTable: "CheckupTicketT",
                        principalColumn: "CheckupTicketId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PictureT_MedicallReportT_MedicallReportId",
                        column: x => x.MedicallReportId,
                        principalTable: "MedicallReportT",
                        principalColumn: "MedicallReportId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TextT",
                columns: table => new
                {
                    TextId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentText = table.Column<int>(nullable: false),
                    CheckupTicketId = table.Column<int>(nullable: true),
                    MedicallReportId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextT", x => x.TextId);
                    table.ForeignKey(
                        name: "FK_TextT_CheckupTicketT_CheckupTicketId",
                        column: x => x.CheckupTicketId,
                        principalTable: "CheckupTicketT",
                        principalColumn: "CheckupTicketId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TextT_MedicallReportT_MedicallReportId",
                        column: x => x.MedicallReportId,
                        principalTable: "MedicallReportT",
                        principalColumn: "MedicallReportId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllegyHealthsT_AllergyId",
                table: "AllegyHealthsT",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_AllegyHealthsT_HealthConditionId",
                table: "AllegyHealthsT",
                column: "HealthConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_CureProgressT_DiagnosisId",
                table: "CureProgressT",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_CureProgressT_MedicallReportId",
                table: "CureProgressT",
                column: "MedicallReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosisActivityPricingsT_CurrentDiagnosisDiagnosisId",
                table: "DiagnosisActivityPricingsT",
                column: "CurrentDiagnosisDiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosisActivityPricingsT_CurrentPricingMedicallActivityPriceId",
                table: "DiagnosisActivityPricingsT",
                column: "CurrentPricingMedicallActivityPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosisTicketsT_CheckupTicketId",
                table: "DiagnosisTicketsT",
                column: "CheckupTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosisTicketsT_DiagnosisId",
                table: "DiagnosisTicketsT",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckupTicketT_CreatedByDoctorId",
                table: "CheckupTicketT",
                column: "CreatedByDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckupTicketT_PatientId",
                table: "CheckupTicketT",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckupTicketT_ToDoctorDoctorId",
                table: "CheckupTicketT",
                column: "ToDoctorDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicallActivityPriceT_MedicallBillId",
                table: "MedicallActivityPriceT",
                column: "MedicallBillId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicallBillT_DiagnosisId",
                table: "MedicallBillT",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicallBillT_DoctorId",
                table: "MedicallBillT",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicallReportT_AuthorDoctorId",
                table: "MedicallReportT",
                column: "AuthorDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicallReportT_PatientId",
                table: "MedicallReportT",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientT_HealthConditionId",
                table: "PatientT",
                column: "HealthConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientT_HomeAddressAddressId",
                table: "PatientT",
                column: "HomeAddressAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTreatmentLogT_DiagnosisId",
                table: "PatientTreatmentLogT",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTreatmentLogT_PatientId",
                table: "PatientTreatmentLogT",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureT_AllergyId",
                table: "PictureT",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureT_CheckupTicketId",
                table: "PictureT",
                column: "CheckupTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureT_MedicallReportId",
                table: "PictureT",
                column: "MedicallReportId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleT_AdminId",
                table: "RoleT",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleT_LoginId",
                table: "RoleT",
                column: "LoginId");

            migrationBuilder.CreateIndex(
                name: "IX_TextT_CheckupTicketId",
                table: "TextT",
                column: "CheckupTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TextT_MedicallReportId",
                table: "TextT",
                column: "MedicallReportId");

            migrationBuilder.CreateIndex(
                name: "IX_UserT_AdminId",
                table: "UserT",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_UserT_DoctorId",
                table: "UserT",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserT_InsureEmpId",
                table: "UserT",
                column: "InsureEmpId");

            migrationBuilder.CreateIndex(
                name: "IX_UserT_LoginId",
                table: "UserT",
                column: "LoginId");

            migrationBuilder.CreateIndex(
                name: "IX_UserT_WorkAddressAddressId",
                table: "UserT",
                column: "WorkAddressAddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllegyHealthsT");

            migrationBuilder.DropTable(
                name: "CureProgressT");

            migrationBuilder.DropTable(
                name: "DiagnosisActivityPricingsT");

            migrationBuilder.DropTable(
                name: "DiagnosisTicketsT");

            migrationBuilder.DropTable(
                name: "PatientTreatmentLogT");

            migrationBuilder.DropTable(
                name: "PictureT");

            migrationBuilder.DropTable(
                name: "RoleT");

            migrationBuilder.DropTable(
                name: "TextT");

            migrationBuilder.DropTable(
                name: "UserT");

            migrationBuilder.DropTable(
                name: "MedicallActivityPriceT");

            migrationBuilder.DropTable(
                name: "AllergyT");

            migrationBuilder.DropTable(
                name: "CheckupTicketT");

            migrationBuilder.DropTable(
                name: "MedicallReportT");

            migrationBuilder.DropTable(
                name: "AdminT");

            migrationBuilder.DropTable(
                name: "InsureEmpT");

            migrationBuilder.DropTable(
                name: "LoginT");

            migrationBuilder.DropTable(
                name: "MedicallBillT");

            migrationBuilder.DropTable(
                name: "PatientT");

            migrationBuilder.DropTable(
                name: "DiagnosisT");

            migrationBuilder.DropTable(
                name: "DoctorT");

            migrationBuilder.DropTable(
                name: "HealthConditionT");

            migrationBuilder.DropTable(
                name: "AddressT");
        }
    }
}
