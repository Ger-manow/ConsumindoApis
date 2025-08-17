using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teste2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Cnpj = table.Column<string>(type: "TEXT", nullable: false),
                    Uf = table.Column<string>(type: "TEXT", nullable: false),
                    Cep = table.Column<string>(type: "TEXT", nullable: false),
                    Pais = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Porte = table.Column<string>(type: "TEXT", nullable: false),
                    Bairro = table.Column<string>(type: "TEXT", nullable: false),
                    Numero = table.Column<string>(type: "TEXT", nullable: false),
                    DddFax = table.Column<string>(type: "TEXT", nullable: false),
                    Municipio = table.Column<string>(type: "TEXT", nullable: false),
                    Logradouro = table.Column<string>(type: "TEXT", nullable: false),
                    CnaeFiscal = table.Column<long>(type: "INTEGER", nullable: false),
                    CodigoPais = table.Column<string>(type: "TEXT", nullable: false),
                    Complemento = table.Column<string>(type: "TEXT", nullable: false),
                    CodigoPorte = table.Column<int>(type: "INTEGER", nullable: false),
                    RazaoSocial = table.Column<string>(type: "TEXT", nullable: false),
                    NomeFantasia = table.Column<string>(type: "TEXT", nullable: false),
                    CapitalSocial = table.Column<decimal>(type: "TEXT", nullable: false),
                    DddTelefone1 = table.Column<string>(type: "TEXT", nullable: false),
                    DddTelefone2 = table.Column<string>(type: "TEXT", nullable: false),
                    OpcaoPeloMei = table.Column<bool>(type: "INTEGER", nullable: true),
                    DescricaoPorte = table.Column<string>(type: "TEXT", nullable: false),
                    CodigoMunicipio = table.Column<int>(type: "INTEGER", nullable: false),
                    NaturezaJuridica = table.Column<string>(type: "TEXT", nullable: false),
                    SituacaoEspecial = table.Column<string>(type: "TEXT", nullable: false),
                    OpcaoPeloSimples = table.Column<bool>(type: "INTEGER", nullable: false),
                    SituacaoCadastral = table.Column<int>(type: "INTEGER", nullable: false),
                    DataOpcaoPeloMei = table.Column<string>(type: "TEXT", nullable: false),
                    DataExclusaoDoMei = table.Column<string>(type: "TEXT", nullable: false),
                    CnaeFiscalDescricao = table.Column<string>(type: "TEXT", nullable: false),
                    CodigoMunicipioIbge = table.Column<int>(type: "INTEGER", nullable: false),
                    DataInicioAtividade = table.Column<string>(type: "TEXT", nullable: false),
                    DataSituacaoEspecial = table.Column<string>(type: "TEXT", nullable: false),
                    DataOpcaoPeloSimples = table.Column<string>(type: "TEXT", nullable: false),
                    DataSituacaoCadastral = table.Column<string>(type: "TEXT", nullable: false),
                    NomeCidadeNoExterior = table.Column<string>(type: "TEXT", nullable: false),
                    CodigoNaturezaJuridica = table.Column<int>(type: "INTEGER", nullable: false),
                    DataExclusaoDoSimples = table.Column<string>(type: "TEXT", nullable: false),
                    MotivoSituacaoCadastral = table.Column<int>(type: "INTEGER", nullable: false),
                    EnteFederativoResponsavel = table.Column<string>(type: "TEXT", nullable: false),
                    IdentificadorMatrizFilial = table.Column<int>(type: "INTEGER", nullable: false),
                    QualificacaoDoResponsavel = table.Column<int>(type: "INTEGER", nullable: false),
                    DescricaoSituacaoCadastral = table.Column<string>(type: "TEXT", nullable: false),
                    DescricaoTipoDeLogradouro = table.Column<string>(type: "TEXT", nullable: false),
                    DescricaoMotivoSituacaoCadastral = table.Column<string>(type: "TEXT", nullable: false),
                    DescricaoIdentificadorMatrizFilial = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Cnpj);
                });

            migrationBuilder.CreateTable(
                name: "CnaeSecundario",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<long>(type: "INTEGER", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    EmpresaCnpj = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CnaeSecundario", x => x.id);
                    table.ForeignKey(
                        name: "FK_CnaeSecundario_Empresas_EmpresaCnpj",
                        column: x => x.EmpresaCnpj,
                        principalTable: "Empresas",
                        principalColumn: "Cnpj");
                });

            migrationBuilder.CreateTable(
                name: "Qsa",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Pais = table.Column<string>(type: "TEXT", nullable: false),
                    NomeSocio = table.Column<string>(type: "TEXT", nullable: false),
                    CodigoPais = table.Column<string>(type: "TEXT", nullable: false),
                    FaixaEtaria = table.Column<string>(type: "TEXT", nullable: false),
                    CnpjCpfDoSocio = table.Column<string>(type: "TEXT", nullable: false),
                    QualificacaoSocio = table.Column<string>(type: "TEXT", nullable: false),
                    CodigoFaixaEtaria = table.Column<int>(type: "INTEGER", nullable: false),
                    DataEntradaSociedade = table.Column<string>(type: "TEXT", nullable: false),
                    IdentificadorDeSocio = table.Column<int>(type: "INTEGER", nullable: false),
                    CpfRepresentanteLegal = table.Column<string>(type: "TEXT", nullable: false),
                    NomeRepresentanteLegal = table.Column<string>(type: "TEXT", nullable: false),
                    CodigoQualificacaoSocio = table.Column<int>(type: "INTEGER", nullable: false),
                    QualificacaoRepresentanteLegal = table.Column<string>(type: "TEXT", nullable: false),
                    CodigoQualificacaoRepresentanteLegal = table.Column<int>(type: "INTEGER", nullable: false),
                    EmpresaCnpj = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qsa", x => x.id);
                    table.ForeignKey(
                        name: "FK_Qsa_Empresas_EmpresaCnpj",
                        column: x => x.EmpresaCnpj,
                        principalTable: "Empresas",
                        principalColumn: "Cnpj");
                });

            migrationBuilder.CreateTable(
                name: "RegimeTributario",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ano = table.Column<int>(type: "INTEGER", nullable: false),
                    CnpjDaScp = table.Column<string>(type: "TEXT", nullable: false),
                    FormaDeTributacao = table.Column<string>(type: "TEXT", nullable: false),
                    QuantidadeDeEscrituracoes = table.Column<int>(type: "INTEGER", nullable: false),
                    EmpresaCnpj = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegimeTributario", x => x.id);
                    table.ForeignKey(
                        name: "FK_RegimeTributario_Empresas_EmpresaCnpj",
                        column: x => x.EmpresaCnpj,
                        principalTable: "Empresas",
                        principalColumn: "Cnpj");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CnaeSecundario_EmpresaCnpj",
                table: "CnaeSecundario",
                column: "EmpresaCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_Qsa_EmpresaCnpj",
                table: "Qsa",
                column: "EmpresaCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_RegimeTributario_EmpresaCnpj",
                table: "RegimeTributario",
                column: "EmpresaCnpj");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CnaeSecundario");

            migrationBuilder.DropTable(
                name: "Qsa");

            migrationBuilder.DropTable(
                name: "RegimeTributario");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
