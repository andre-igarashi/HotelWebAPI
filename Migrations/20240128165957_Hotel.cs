using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Hotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdaptacaoQuarto",
                columns: table => new
                {
                    codAdaptacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoAdaptacao = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_codAdaptacao", x => x.codAdaptacao);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    endereco = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    nacionalidade = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    telefone = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_idCliente", x => x.idCliente);
                });

            migrationBuilder.CreateTable(
                name: "Filial",
                columns: table => new
                {
                    idFilial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeFilial = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    enderecoFilial = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    quartosSolteiro = table.Column<int>(type: "int", nullable: true),
                    quartosCasal = table.Column<int>(type: "int", nullable: true),
                    quartosFamilia = table.Column<int>(type: "int", nullable: true),
                    quartosPresidencial = table.Column<int>(type: "int", nullable: true),
                    estrelas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_idFilial", x => x.idFilial);
                });

            migrationBuilder.CreateTable(
                name: "FormaPagamento",
                columns: table => new
                {
                    codTipoPagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoPagamento = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_codTipoPagamento", x => x.codTipoPagamento);
                });

            migrationBuilder.CreateTable(
                name: "Funcao",
                columns: table => new
                {
                    codFuncao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    funcao = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    descricao = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_codFuncao", x => x.codFuncao);
                });

            migrationBuilder.CreateTable(
                name: "ServicoLavanderia",
                columns: table => new
                {
                    idServicoLavanderia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeServico = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_idServicoLavanderia", x => x.idServicoLavanderia);
                });

            migrationBuilder.CreateTable(
                name: "TipoQuarto",
                columns: table => new
                {
                    codTipoQuarto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoQuarto = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    descricao = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    capacidadeMaxima = table.Column<int>(type: "int", nullable: false),
                    capacidadeOpcional = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_codTipoQuarto", x => x.codTipoQuarto);
                });

            migrationBuilder.CreateTable(
                name: "ItemConsumivelFilial",
                columns: table => new
                {
                    codItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    valorUnitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    idFilialItem = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_codItem", x => x.codItem);
                    table.ForeignKey(
                        name: "Fk_idFilialItem",
                        column: x => x.idFilialItem,
                        principalTable: "Filial",
                        principalColumn: "idFilial");
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal",
                columns: table => new
                {
                    numNota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valorTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValue: 0m),
                    codTipoPagamento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_numNota", x => x.numNota);
                    table.ForeignKey(
                        name: "Fk_idFormaPagamento",
                        column: x => x.codTipoPagamento,
                        principalTable: "FormaPagamento",
                        principalColumn: "codTipoPagamento");
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    idFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    idFuncao = table.Column<int>(type: "int", nullable: false),
                    dataNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    endereco = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    telefone = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    idFilialFuncionario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_idFuncionario", x => x.idFuncionario);
                    table.ForeignKey(
                        name: "Fk_idFilialFuncionario",
                        column: x => x.idFilialFuncionario,
                        principalTable: "Filial",
                        principalColumn: "idFilial");
                    table.ForeignKey(
                        name: "Fk_idFuncao",
                        column: x => x.idFuncao,
                        principalTable: "Funcao",
                        principalColumn: "codFuncao");
                });

            migrationBuilder.CreateTable(
                name: "Quarto",
                columns: table => new
                {
                    numQuarto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idTipoQuarto = table.Column<int>(type: "int", nullable: false),
                    idAdaptacao = table.Column<int>(type: "int", nullable: true),
                    idFilialQuarto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_numQuarto", x => x.numQuarto);
                    table.ForeignKey(
                        name: "Fk_idAdaptacao",
                        column: x => x.idAdaptacao,
                        principalTable: "AdaptacaoQuarto",
                        principalColumn: "codAdaptacao");
                    table.ForeignKey(
                        name: "Fk_idFilialQuarto",
                        column: x => x.idFilialQuarto,
                        principalTable: "Filial",
                        principalColumn: "idFilial");
                    table.ForeignKey(
                        name: "Fk_idTipoQuarto",
                        column: x => x.idTipoQuarto,
                        principalTable: "TipoQuarto",
                        principalColumn: "codTipoQuarto");
                });

            migrationBuilder.CreateTable(
                name: "ValorQuartoFilial",
                columns: table => new
                {
                    idValorQuartoFilial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idFilial = table.Column<int>(type: "int", nullable: true),
                    codTipoQuarto = table.Column<int>(type: "int", nullable: true),
                    diariaQuartoFilial = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_idValorQuartoFilial", x => x.idValorQuartoFilial);
                    table.ForeignKey(
                        name: "Fk_codTipoQuarto",
                        column: x => x.codTipoQuarto,
                        principalTable: "TipoQuarto",
                        principalColumn: "codTipoQuarto");
                    table.ForeignKey(
                        name: "Fk_idFilial",
                        column: x => x.idFilial,
                        principalTable: "Filial",
                        principalColumn: "idFilial");
                });

            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    codConta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idNotaConta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_codConta", x => x.codConta);
                    table.ForeignKey(
                        name: "Fk_numNota",
                        column: x => x.idNotaConta,
                        principalTable: "NotaFiscal",
                        principalColumn: "numNota");
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    idReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idClienteReserva = table.Column<int>(type: "int", nullable: false),
                    idFuncionarioReserva = table.Column<int>(type: "int", nullable: false),
                    adicionarColchao = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_idReserva", x => x.idReserva);
                    table.ForeignKey(
                        name: "Fk_idClienteReserva",
                        column: x => x.idClienteReserva,
                        principalTable: "Cliente",
                        principalColumn: "idCliente");
                    table.ForeignKey(
                        name: "Fk_idFuncionarioReserva",
                        column: x => x.idFuncionarioReserva,
                        principalTable: "Funcionario",
                        principalColumn: "idFuncionario");
                });

            migrationBuilder.CreateTable(
                name: "ItemConta",
                columns: table => new
                {
                    codItem = table.Column<int>(type: "int", nullable: false),
                    codConta = table.Column<int>(type: "int", nullable: false),
                    item = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    origem = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    acrescimoEntrega = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_ItemConta", x => new { x.codItem, x.codConta });
                    table.ForeignKey(
                        name: "Fk_codConta",
                        column: x => x.codConta,
                        principalTable: "Conta",
                        principalColumn: "codConta");
                    table.ForeignKey(
                        name: "Fk_codItem",
                        column: x => x.codItem,
                        principalTable: "ItemConsumivelFilial",
                        principalColumn: "codItem");
                });

            migrationBuilder.CreateTable(
                name: "ItemLavanderiaConta",
                columns: table => new
                {
                    codItemLavanderia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    servico = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    codConta = table.Column<int>(type: "int", nullable: true),
                    idServicoLavanderia = table.Column<int>(type: "int", nullable: true),
                    quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_ItemLavanderiaConta", x => x.codItemLavanderia);
                    table.ForeignKey(
                        name: "Fk_codContaLavanderia",
                        column: x => x.codConta,
                        principalTable: "Conta",
                        principalColumn: "codConta");
                    table.ForeignKey(
                        name: "Fk_idServicoLavanderia",
                        column: x => x.idServicoLavanderia,
                        principalTable: "ServicoLavanderia",
                        principalColumn: "idServicoLavanderia");
                });

            migrationBuilder.CreateTable(
                name: "ReservaQuarto",
                columns: table => new
                {
                    idReservaQuarto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataCheckIn = table.Column<DateOnly>(type: "date", nullable: false),
                    dataCheckOut = table.Column<DateOnly>(type: "date", nullable: false),
                    cancelada = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    idReserva = table.Column<int>(type: "int", nullable: true),
                    idQuarto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_idReservaQuarto", x => x.idReservaQuarto);
                    table.ForeignKey(
                        name: "Fk_idReserva",
                        column: x => x.idReserva,
                        principalTable: "Reserva",
                        principalColumn: "idReserva");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conta_idNotaConta",
                table: "Conta",
                column: "idNotaConta");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_idFilialFuncionario",
                table: "Funcionario",
                column: "idFilialFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_idFuncao",
                table: "Funcionario",
                column: "idFuncao");

            migrationBuilder.CreateIndex(
                name: "IX_ItemConsumivelFilial_idFilialItem",
                table: "ItemConsumivelFilial",
                column: "idFilialItem");

            migrationBuilder.CreateIndex(
                name: "IX_ItemConta_codConta",
                table: "ItemConta",
                column: "codConta");

            migrationBuilder.CreateIndex(
                name: "IX_ItemLavanderiaConta_codConta",
                table: "ItemLavanderiaConta",
                column: "codConta");

            migrationBuilder.CreateIndex(
                name: "IX_ItemLavanderiaConta_idServicoLavanderia",
                table: "ItemLavanderiaConta",
                column: "idServicoLavanderia");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscal_codTipoPagamento",
                table: "NotaFiscal",
                column: "codTipoPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_Quarto_idAdaptacao",
                table: "Quarto",
                column: "idAdaptacao");

            migrationBuilder.CreateIndex(
                name: "IX_Quarto_idFilialQuarto",
                table: "Quarto",
                column: "idFilialQuarto");

            migrationBuilder.CreateIndex(
                name: "IX_Quarto_idTipoQuarto",
                table: "Quarto",
                column: "idTipoQuarto");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_idClienteReserva",
                table: "Reserva",
                column: "idClienteReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_idFuncionarioReserva",
                table: "Reserva",
                column: "idFuncionarioReserva");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaQuarto_idReserva",
                table: "ReservaQuarto",
                column: "idReserva");

            migrationBuilder.CreateIndex(
                name: "IX_ValorQuartoFilial_codTipoQuarto",
                table: "ValorQuartoFilial",
                column: "codTipoQuarto");

            migrationBuilder.CreateIndex(
                name: "IX_ValorQuartoFilial_idFilial",
                table: "ValorQuartoFilial",
                column: "idFilial");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemConta");

            migrationBuilder.DropTable(
                name: "ItemLavanderiaConta");

            migrationBuilder.DropTable(
                name: "Quarto");

            migrationBuilder.DropTable(
                name: "ReservaQuarto");

            migrationBuilder.DropTable(
                name: "ValorQuartoFilial");

            migrationBuilder.DropTable(
                name: "ItemConsumivelFilial");

            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "ServicoLavanderia");

            migrationBuilder.DropTable(
                name: "AdaptacaoQuarto");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "TipoQuarto");

            migrationBuilder.DropTable(
                name: "NotaFiscal");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "FormaPagamento");

            migrationBuilder.DropTable(
                name: "Filial");

            migrationBuilder.DropTable(
                name: "Funcao");
        }
    }
}
