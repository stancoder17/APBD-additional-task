﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI_Conferences.DAT;

#nullable disable

namespace WebAPI_Conferences.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250617182531_AddModelsAndExampleSeeding")]
    partial class AddModelsAndExampleSeeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPI_Conferences.Models.Event", b =>
                {
                    b.Property<int>("IdEvent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEvent"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("MaxPeople")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdEvent");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            IdEvent = 1,
                            Date = new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A conference about the latest tech.",
                            MaxPeople = 100,
                            Title = "Tech Conference 2025"
                        },
                        new
                        {
                            IdEvent = 2,
                            Date = new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Hands-on workshop on AI.",
                            MaxPeople = 50,
                            Title = "AI Workshop"
                        });
                });

            modelBuilder.Entity("WebAPI_Conferences.Models.Participant", b =>
                {
                    b.Property<int>("IdParticipant")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdParticipant"));

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdParticipant");

                    b.ToTable("Participants");

                    b.HasData(
                        new
                        {
                            IdParticipant = 1,
                            Email = "john.doe@example.com",
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            IdParticipant = 2,
                            Email = "anna.k@example.com",
                            FirstName = "Anna",
                            LastName = "Kowalska"
                        },
                        new
                        {
                            IdParticipant = 3,
                            Email = "mike.j@example.com",
                            FirstName = "Mike",
                            LastName = "Johnson"
                        },
                        new
                        {
                            IdParticipant = 4,
                            Email = "sara.s@example.com",
                            FirstName = "Sara",
                            LastName = "Smith"
                        },
                        new
                        {
                            IdParticipant = 5,
                            Email = "tom.c@example.com",
                            FirstName = "Tom",
                            LastName = "Clark"
                        },
                        new
                        {
                            IdParticipant = 6,
                            Email = "ewa.n@example.com",
                            FirstName = "Ewa",
                            LastName = "Nowak"
                        },
                        new
                        {
                            IdParticipant = 7,
                            Email = "liam.b@example.com",
                            FirstName = "Liam",
                            LastName = "Brown"
                        },
                        new
                        {
                            IdParticipant = 8,
                            Email = "olga.z@example.com",
                            FirstName = "Olga",
                            LastName = "Zielińska"
                        },
                        new
                        {
                            IdParticipant = 9,
                            Email = "peter.a@example.com",
                            FirstName = "Peter",
                            LastName = "Adams"
                        },
                        new
                        {
                            IdParticipant = 10,
                            Email = "marta.w@example.com",
                            FirstName = "Marta",
                            LastName = "Wiśniewska"
                        });
                });

            modelBuilder.Entity("WebAPI_Conferences.Models.ParticipantEvent", b =>
                {
                    b.Property<int>("IdEvent")
                        .HasColumnType("int");

                    b.Property<int>("IdParticipant")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdEvent", "IdParticipant");

                    b.HasIndex("IdParticipant");

                    b.ToTable("Participant_Event");

                    b.HasData(
                        new
                        {
                            IdEvent = 1,
                            IdParticipant = 1,
                            RegistrationDate = new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdEvent = 1,
                            IdParticipant = 2,
                            RegistrationDate = new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdEvent = 1,
                            IdParticipant = 3,
                            RegistrationDate = new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdEvent = 2,
                            IdParticipant = 4,
                            RegistrationDate = new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdEvent = 2,
                            IdParticipant = 5,
                            RegistrationDate = new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("WebAPI_Conferences.Models.Speaker", b =>
                {
                    b.Property<int>("IdSpeaker")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSpeaker"));

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdSpeaker");

                    b.ToTable("Speakers");

                    b.HasData(
                        new
                        {
                            IdSpeaker = 1,
                            Email = "alice@example.com",
                            FirstName = "Alice",
                            LastName = "Johnson"
                        },
                        new
                        {
                            IdSpeaker = 2,
                            Email = "bob@example.com",
                            FirstName = "Bob",
                            LastName = "Smith"
                        },
                        new
                        {
                            IdSpeaker = 3,
                            Email = "carol@example.com",
                            FirstName = "Carol",
                            LastName = "Davis"
                        },
                        new
                        {
                            IdSpeaker = 4,
                            Email = "david@example.com",
                            FirstName = "David",
                            LastName = "Lee"
                        });
                });

            modelBuilder.Entity("WebAPI_Conferences.Models.SpeakerEvent", b =>
                {
                    b.Property<int>("IdEvent")
                        .HasColumnType("int");

                    b.Property<int>("IdSpeaker")
                        .HasColumnType("int");

                    b.Property<int>("SpeakingTime")
                        .HasColumnType("int");

                    b.HasKey("IdEvent", "IdSpeaker");

                    b.HasIndex("IdSpeaker");

                    b.ToTable("Speaker_Event");

                    b.HasData(
                        new
                        {
                            IdEvent = 1,
                            IdSpeaker = 1,
                            SpeakingTime = 45
                        },
                        new
                        {
                            IdEvent = 1,
                            IdSpeaker = 2,
                            SpeakingTime = 30
                        },
                        new
                        {
                            IdEvent = 2,
                            IdSpeaker = 3,
                            SpeakingTime = 60
                        },
                        new
                        {
                            IdEvent = 2,
                            IdSpeaker = 4,
                            SpeakingTime = 50
                        });
                });

            modelBuilder.Entity("WebAPI_Conferences.Models.ParticipantEvent", b =>
                {
                    b.HasOne("WebAPI_Conferences.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("IdEvent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI_Conferences.Models.Participant", "Participant")
                        .WithMany("EventRegistrations")
                        .HasForeignKey("IdParticipant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("WebAPI_Conferences.Models.SpeakerEvent", b =>
                {
                    b.HasOne("WebAPI_Conferences.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("IdEvent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI_Conferences.Models.Speaker", "Speaker")
                        .WithMany("EventRegistrations")
                        .HasForeignKey("IdSpeaker")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Speaker");
                });

            modelBuilder.Entity("WebAPI_Conferences.Models.Participant", b =>
                {
                    b.Navigation("EventRegistrations");
                });

            modelBuilder.Entity("WebAPI_Conferences.Models.Speaker", b =>
                {
                    b.Navigation("EventRegistrations");
                });
#pragma warning restore 612, 618
        }
    }
}
