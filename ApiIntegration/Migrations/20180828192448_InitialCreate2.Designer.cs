﻿// <auto-generated />
using ApiIntegration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ApiIntegration.Migrations
{
    [DbContext(typeof(LoginContext))]
    [Migration("20180828192448_InitialCreate2")]
    partial class InitialCreate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiIntegration.Models.LoginDto", b =>
                {
                    b.Property<long>("LoginId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress");

                    b.Property<string>("Password");

                    b.HasKey("LoginId");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("ApiIntegration.Models.UserProfileDto", b =>
                {
                    b.Property<long>("Id");

                    b.Property<int>("Age");

                    b.Property<string>("City");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("LoginDtoForeignKey");

                    b.Property<string>("Password");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<int>("Zipcode");

                    b.HasKey("Id");

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("ApiIntegration.Models.UserProfileDto", b =>
                {
                    b.HasOne("ApiIntegration.Models.LoginDto", "LoginDto")
                        .WithOne("UsepProfileDto")
                        .HasForeignKey("ApiIntegration.Models.UserProfileDto", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
