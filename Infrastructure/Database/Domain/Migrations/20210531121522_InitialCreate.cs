using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Database.Domain.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OriginalPrice = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "OriginalPrice", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("fa1e8da2-591a-42bd-9114-9b94583cc4ad"), "孩我有。有種樣正活禮，持的大銀道非劇些……上上關展代力在氣友國外少有經代覺能子力命民在一化新著館魚，方花得定這、大新和力價自者酒提前價年行導招之十團常指片入比、當乎下電方看四。", 2000.0, 2, "地要麼倒分課傳確地角了" },
                    { new Guid("ef22a3bd-bda1-4ec8-b965-99efbdd8de40"), "好身會了驚業的立公事爸著法火約腦先聲這，你外死什農是對成加？人立發；在帶加人許了，道班名當出時地裡設腦型然，禮過見化點待時見所師高多國內節識極直重，你好格，他要天謝朋時心物委。", 400.0, 1, "權是了草這親遠要" },
                    { new Guid("c6b300c0-e86b-4c50-9d0f-6cd051cc9ad3"), "麼歡以們可老指地們屋當你我能一器的工活一，客度春年著雄、盡記上不：古育人住企造客行黃是持期麗上眼起以，曾一稱不看！法上山家有故營的何王一信海境；失識不市單老：像照書最不園幾就送統著石告因，停活夫我銷張過天然葉心把，例走地技國深、小初民是息！", 600.0, 0, "型童受了反聽" },
                    { new Guid("54c572c1-001c-43d9-ac73-d55b31dcb8de"), "半飛性好要體；給動更多自車麼時意也我價速與最，議本光開來簡師原觀和時。雖品春電理的……等加法一文行者制校的算知大趣土說藥母安育家樂遠善身告有加不。", 3800.0, 2, "政不書時特上滿\n" },
                    { new Guid("ca2e93a5-f3fa-4ab9-891f-5ba51f50aacf"), "活以單學作漸土布紅，高建電中學預子轉根公下的很天！組有你種，臺一太學興名事各分縣還義戲，面這財裡空而；作存導臺水書。麼訴燈示調大受動必市臺會美方場大重活間。民不該學之他的級的走。", 1500.0, 2, "比回無道前民什假去器算天" },
                    { new Guid("444fda36-c643-4d70-90ec-42779cc2e80f"), "生書業嗎事。型以克持聲她人輕經：錯治平步心裝家無一不源是除？不利弟巴無況的推元面覺。愛自打關葉；病為新就你命性西，取氣反又身家的那很使學開回每專場買時學西！", 1100.0, 2, "下房在界百百提是民列" },
                    { new Guid("7e1f51df-6015-47eb-8ab5-2913ca621598"), "起水腳我共德，大務心光復認快相由，大友法有來年……道自張較愛國有傷，東在口許心一家眾我的岸樣建改法、象面約關獲只兒！斯是老；看著於不斯，自防經式要政連故天日校到東到才任親里廠。", 2200.0, 2, "就今不費這古心" },
                    { new Guid("db025b9c-6efe-4ce5-8693-2372ecdf1d3c"), "超總解人起、急相善斯此乎時沒和界件見線衣新方近是接所做你照，中書後、球景白。持面師片要強軍河了演。", 2700.0, 1, "共山女性星因數我我遊" },
                    { new Guid("3fcdadb2-db97-44ec-ab99-62f01b0b22bc"), "的上自了利以不，情體麼、候面提我場是我本：樣創想臉最。進環之萬常，因行品，錢的多母金聲城心分好老民不部曾病始有方打產，世年接子為大之說。接熱優新母說原像一官的氣上、房神得下她和地認懷統得領月力。", 1400.0, 0, "文下一人了類色兒師人也以子" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ProductId", "Status", "Url" },
                values: new object[,]
                {
                    { 1, new Guid("fa1e8da2-591a-42bd-9114-9b94583cc4ad"), 1, "http://placekitten.com/g/300/300" },
                    { 23, new Guid("7e1f51df-6015-47eb-8ab5-2913ca621598"), 1, "http://placekitten.com/g/300/300" },
                    { 22, new Guid("7e1f51df-6015-47eb-8ab5-2913ca621598"), 1, "http://placekitten.com/g/300/300" },
                    { 21, new Guid("7e1f51df-6015-47eb-8ab5-2913ca621598"), 1, "http://placekitten.com/g/300/300" },
                    { 20, new Guid("7e1f51df-6015-47eb-8ab5-2913ca621598"), 1, "http://placekitten.com/g/300/300" },
                    { 19, new Guid("7e1f51df-6015-47eb-8ab5-2913ca621598"), 1, "http://placekitten.com/g/300/300" },
                    { 18, new Guid("444fda36-c643-4d70-90ec-42779cc2e80f"), 1, "http://placekitten.com/g/300/300" },
                    { 17, new Guid("444fda36-c643-4d70-90ec-42779cc2e80f"), 1, "http://placekitten.com/g/300/300" },
                    { 16, new Guid("444fda36-c643-4d70-90ec-42779cc2e80f"), 1, "http://placekitten.com/g/300/300" },
                    { 15, new Guid("444fda36-c643-4d70-90ec-42779cc2e80f"), 1, "http://placekitten.com/g/300/300" },
                    { 14, new Guid("ca2e93a5-f3fa-4ab9-891f-5ba51f50aacf"), 1, "http://placekitten.com/g/300/300" },
                    { 24, new Guid("3fcdadb2-db97-44ec-ab99-62f01b0b22bc"), 1, "http://placekitten.com/g/300/300" },
                    { 13, new Guid("ca2e93a5-f3fa-4ab9-891f-5ba51f50aacf"), 1, "http://placekitten.com/g/300/300" },
                    { 11, new Guid("54c572c1-001c-43d9-ac73-d55b31dcb8de"), 1, "http://placekitten.com/g/300/300" },
                    { 10, new Guid("c6b300c0-e86b-4c50-9d0f-6cd051cc9ad3"), 1, "http://placekitten.com/g/300/300" },
                    { 9, new Guid("c6b300c0-e86b-4c50-9d0f-6cd051cc9ad3"), 1, "http://placekitten.com/g/300/300" },
                    { 8, new Guid("c6b300c0-e86b-4c50-9d0f-6cd051cc9ad3"), 1, "http://placekitten.com/g/300/300" },
                    { 7, new Guid("c6b300c0-e86b-4c50-9d0f-6cd051cc9ad3"), 1, "http://placekitten.com/g/300/300" },
                    { 6, new Guid("ef22a3bd-bda1-4ec8-b965-99efbdd8de40"), 1, "http://placekitten.com/g/300/300" },
                    { 5, new Guid("ef22a3bd-bda1-4ec8-b965-99efbdd8de40"), 1, "http://placekitten.com/g/300/300" },
                    { 4, new Guid("ef22a3bd-bda1-4ec8-b965-99efbdd8de40"), 1, "http://placekitten.com/g/300/300" },
                    { 3, new Guid("fa1e8da2-591a-42bd-9114-9b94583cc4ad"), 1, "http://placekitten.com/g/300/300" },
                    { 2, new Guid("fa1e8da2-591a-42bd-9114-9b94583cc4ad"), 1, "http://placekitten.com/g/300/300" },
                    { 12, new Guid("54c572c1-001c-43d9-ac73-d55b31dcb8de"), 1, "http://placekitten.com/g/300/300" },
                    { 25, new Guid("3fcdadb2-db97-44ec-ab99-62f01b0b22bc"), 1, "http://placekitten.com/g/300/300" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
