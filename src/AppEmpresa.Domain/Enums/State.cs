using AppEmpresa.Utils.Attributes;
using System.ComponentModel;

namespace AppEmpresa.Domain.Enums
{
    public enum State
    {
        [Code("")]
        [Description("Escolha um Estado")]
        EscolhaUmEstado,

        [Code("AC")]
        [Description("Acre")]
        Acre,

        [Code("AL")]
        [Description("Alagoas")]
        Alagoas,

        [Code("AP")]
        [Description("Amapá")]
        Amapa,

        [Code("AM")]
        [Description("Amazonas")]
        Amazonas,

        [Code("BA")]
        [Description("Bahia")]
        Bahia,

        [Code("CE")]
        [Description("Ceará")]
        Ceara,

        [Code("ES")]
        [Description("Espírito Santo")]
        EspiritoSanto,

        [Code("GO")]
        [Description("Goiás")]
        Goias,

        [Code("MA")]
        [Description("Maranhão")]
        Maranhao,

        [Code("MT")]
        [Description("Mato Grosso")]
        MatoGrosso,

        [Code("MS")]
        [Description("Mato Grosso do Sul")]
        MatoGrossoDoSul,

        [Code("MG")]
        [Description("Minas Gerais")]
        MinasGerais,

        [Code("PA")]
        [Description("Pará")]
        Para,

        [Code("PB")]
        [Description("Paraíba")]
        Paraiba,

        [Code("PR")]
        [Description("Paraná")]
        Parana,

        [Code("PE")]
        [Description("Pernambuco")]
        Pernambuco,

        [Code("PI")]
        [Description("Piauí")]
        Piaui,

        [Code("RJ")]
        [Description("Rio de Janeiro")]
        RioDeJaneiro,

        [Code("RN")]
        [Description("Rio Grande do Norte")]
        RioGrandeDoNorte,

        [Code("RS")]
        [Description("Rio Grande do Sul")]
        RioGrandeDoSul,

        [Code("RO")]
        [Description("Rondônia")]
        Rondonia,

        [Code("RR")]
        [Description("Roraima")]
        Roraima,

        [Code("SC")]
        [Description("Santa Catarina")]
        SantaCatarina,

        [Code("SP")]
        [Description("São Paulo")]
        SaoPaulo,

        [Code("SE")]
        [Description("Sergipe")]
        Sergipe,

        [Code("TO")]
        [Description("Tocantins")]
        Tocantins,

        [Code("DF")]
        [Description("Distrito Federal")]
        DistritoFederal
    }
}