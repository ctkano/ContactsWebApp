function displayFrame(inputName)
{
    if (inputName === "Natural person")
    {
        $("#TradeName_Div").hide();
        $("#Birthday_Div").show();
        $("#Gender_Div").show();
        $("label[for*='MainName']").text("Name");
        $("label[for*='DocumentNumber']").text("CPF");
    }
    else if (inputName === "Legal person")
    {
        $("#TradeName_Div").show();
        $("#Birthday_Div").hide();
        $("#Gender_Div").hide();
        $("label[for*='MainName']").text("Company Name");
        $("label[for*='DocumentNumber']").text("CNPJ");
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
    displayFrame($("input[name='ContactType']:checked").val());
}

$(document).ready(function () {    
    $("input[name='ContactType']").click(function () {
        displayFrame($(this).val());
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