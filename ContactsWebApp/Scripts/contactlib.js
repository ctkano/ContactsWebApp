function displayDiv(inputName)
{
    if (inputName === "Natural person")
    {
        $("#TradeName_Div").hide();
        $("#Birthday_Div").show();
        $("#Gender_Div").show();
    }
    else if (inputName === "Legal person")
    {
        $("#TradeName_Div").show();
        $("#Birthday_Div").hide();
        $("#Gender_Div").hide();
    }
}

function changeLabel(inputName)
{
    if (inputName === "Natural person")
    {
        $(".MainName").text("Name");
        $(".DocumentNumber").text("CPF");
    }
    else if (inputName === "Legal person")
    {
        $(".MainName").text("Company Name");
        $(".DocumentNumber").text("CNPJ");
    }
}

function maskDocumentNumberInitializer(object)
{
    obj = object

    if ($("input[name='ContactType']:checked").val() === "Natural person")
        mask = cpfPatternMask
    else if ($("input[name='ContactType']:checked").val() === "Legal person")
        mask = cnpjPatternMask
        
    setTimeout("maskDocumentNumber()", 1)
}

function maskDocumentNumber()
{
    obj.value = mask(obj.value)
}

function cnpjPatternMask(cnpj)
{
    cnpj = cnpj.replace(/\D/g, "")
    cnpj = cnpj.replace(/^(\d{2})(\d)/, "$1.$2")
    cnpj = cnpj.replace(/^(\d{2})\.(\d{3})(\d)/, "$1.$2.$3")
    cnpj = cnpj.replace(/\.(\d{3})(\d)/, ".$1/$2")
    cnpj = cnpj.replace(/(\d{4})(\d)/, "$1-$2")
    return cnpj
}

function cpfPatternMask(cpf) {
    cpf = cpf.replace(/\D/g, "")
    cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2")
    cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2")
    cpf = cpf.replace(/(\d{3})(\d{1,2})$/, "$1-$2")
    return cpf
}

window.onload = function () {
    displayDiv($("input[name='ContactType']:checked").val());
    changeLabel($("input[name='ContactType']:checked").val());
}

$(document).ready(function () {    
    $("input[name='ContactType']").click(function () {
        displayDiv($(this).val());
        changeLabel($(this).val());
    });
});

$(document).ready(function () {
    $("input[name='DocumentNumber']").keyup(function () {
        maskDocumentNumberInitializer(this);
    });
    $("input[name='DocumentNumber']").click(function () {
        maskDocumentNumberInitializer(this);
    });
});