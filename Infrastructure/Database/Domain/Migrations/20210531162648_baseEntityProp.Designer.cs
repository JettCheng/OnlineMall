﻿// <auto-generated />
using System;
using Infrastructure.Database.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Database.Domain.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210531162648_baseEntityProp")]
    partial class baseEntityProp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("OriginalPrice")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fa1e8da2-591a-42bd-9114-9b94583cc4ad"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "孩我有。有種樣正活禮，持的大銀道非劇些……上上關展代力在氣友國外少有經代覺能子力命民在一化新著館魚，方花得定這、大新和力價自者酒提前價年行導招之十團常指片入比、當乎下電方看四。",
                            OriginalPrice = 2000.0,
                            Status = 2,
                            Title = "地要麼倒分課傳確地角了"
                        },
                        new
                        {
                            Id = new Guid("ef22a3bd-bda1-4ec8-b965-99efbdd8de40"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "好身會了驚業的立公事爸著法火約腦先聲這，你外死什農是對成加？人立發；在帶加人許了，道班名當出時地裡設腦型然，禮過見化點待時見所師高多國內節識極直重，你好格，他要天謝朋時心物委。",
                            OriginalPrice = 400.0,
                            Status = 1,
                            Title = "權是了草這親遠要"
                        },
                        new
                        {
                            Id = new Guid("c6b300c0-e86b-4c50-9d0f-6cd051cc9ad3"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "麼歡以們可老指地們屋當你我能一器的工活一，客度春年著雄、盡記上不：古育人住企造客行黃是持期麗上眼起以，曾一稱不看！法上山家有故營的何王一信海境；失識不市單老：像照書最不園幾就送統著石告因，停活夫我銷張過天然葉心把，例走地技國深、小初民是息！",
                            OriginalPrice = 600.0,
                            Status = 0,
                            Title = "型童受了反聽"
                        },
                        new
                        {
                            Id = new Guid("54c572c1-001c-43d9-ac73-d55b31dcb8de"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "半飛性好要體；給動更多自車麼時意也我價速與最，議本光開來簡師原觀和時。雖品春電理的……等加法一文行者制校的算知大趣土說藥母安育家樂遠善身告有加不。",
                            OriginalPrice = 3800.0,
                            Status = 2,
                            Title = "政不書時特上滿\n"
                        },
                        new
                        {
                            Id = new Guid("ca2e93a5-f3fa-4ab9-891f-5ba51f50aacf"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "活以單學作漸土布紅，高建電中學預子轉根公下的很天！組有你種，臺一太學興名事各分縣還義戲，面這財裡空而；作存導臺水書。麼訴燈示調大受動必市臺會美方場大重活間。民不該學之他的級的走。",
                            OriginalPrice = 1500.0,
                            Status = 2,
                            Title = "比回無道前民什假去器算天"
                        },
                        new
                        {
                            Id = new Guid("444fda36-c643-4d70-90ec-42779cc2e80f"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "生書業嗎事。型以克持聲她人輕經：錯治平步心裝家無一不源是除？不利弟巴無況的推元面覺。愛自打關葉；病為新就你命性西，取氣反又身家的那很使學開回每專場買時學西！",
                            OriginalPrice = 1100.0,
                            Status = 2,
                            Title = "下房在界百百提是民列"
                        },
                        new
                        {
                            Id = new Guid("7e1f51df-6015-47eb-8ab5-2913ca621598"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "起水腳我共德，大務心光復認快相由，大友法有來年……道自張較愛國有傷，東在口許心一家眾我的岸樣建改法、象面約關獲只兒！斯是老；看著於不斯，自防經式要政連故天日校到東到才任親里廠。",
                            OriginalPrice = 2200.0,
                            Status = 2,
                            Title = "就今不費這古心"
                        },
                        new
                        {
                            Id = new Guid("db025b9c-6efe-4ce5-8693-2372ecdf1d3c"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "超總解人起、急相善斯此乎時沒和界件見線衣新方近是接所做你照，中書後、球景白。持面師片要強軍河了演。",
                            OriginalPrice = 2700.0,
                            Status = 1,
                            Title = "共山女性星因數我我遊"
                        },
                        new
                        {
                            Id = new Guid("3fcdadb2-db97-44ec-ab99-62f01b0b22bc"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "的上自了利以不，情體麼、候面提我場是我本：樣創想臉最。進環之萬常，因行品，錢的多母金聲城心分好老民不部曾病始有方打產，世年接子為大之說。接熱優新母說原像一官的氣上、房神得下她和地認懷統得領月力。",
                            OriginalPrice = 1400.0,
                            Status = 0,
                            Title = "文下一人了類色兒師人也以子"
                        });
                });

            modelBuilder.Entity("Core.Entities.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("fa1e8da2-591a-42bd-9114-9b94583cc4ad"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("fa1e8da2-591a-42bd-9114-9b94583cc4ad"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("fa1e8da2-591a-42bd-9114-9b94583cc4ad"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("ef22a3bd-bda1-4ec8-b965-99efbdd8de40"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("ef22a3bd-bda1-4ec8-b965-99efbdd8de40"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("ef22a3bd-bda1-4ec8-b965-99efbdd8de40"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("c6b300c0-e86b-4c50-9d0f-6cd051cc9ad3"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("c6b300c0-e86b-4c50-9d0f-6cd051cc9ad3"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("c6b300c0-e86b-4c50-9d0f-6cd051cc9ad3"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("c6b300c0-e86b-4c50-9d0f-6cd051cc9ad3"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 11,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("54c572c1-001c-43d9-ac73-d55b31dcb8de"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 12,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("54c572c1-001c-43d9-ac73-d55b31dcb8de"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 13,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("ca2e93a5-f3fa-4ab9-891f-5ba51f50aacf"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 14,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("ca2e93a5-f3fa-4ab9-891f-5ba51f50aacf"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 15,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("444fda36-c643-4d70-90ec-42779cc2e80f"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 16,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("444fda36-c643-4d70-90ec-42779cc2e80f"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 17,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("444fda36-c643-4d70-90ec-42779cc2e80f"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 18,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("444fda36-c643-4d70-90ec-42779cc2e80f"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 19,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("7e1f51df-6015-47eb-8ab5-2913ca621598"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 20,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("7e1f51df-6015-47eb-8ab5-2913ca621598"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 21,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("7e1f51df-6015-47eb-8ab5-2913ca621598"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 22,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("7e1f51df-6015-47eb-8ab5-2913ca621598"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 23,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("7e1f51df-6015-47eb-8ab5-2913ca621598"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 24,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("3fcdadb2-db97-44ec-ab99-62f01b0b22bc"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        },
                        new
                        {
                            Id = 25,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("3fcdadb2-db97-44ec-ab99-62f01b0b22bc"),
                            Status = 1,
                            Url = "http://placekitten.com/g/300/300"
                        });
                });

            modelBuilder.Entity("Core.Entities.ProductImage", b =>
                {
                    b.HasOne("Core.Entities.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Core.Entities.Product", b =>
                {
                    b.Navigation("ProductImages");
                });
#pragma warning restore 612, 618
        }
    }
}
