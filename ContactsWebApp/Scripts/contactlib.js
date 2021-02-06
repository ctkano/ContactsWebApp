function displayInformation(contactType)
{
    if (contactType === undefined) {
        contactType = $("#ContactTypeValue").first().text().replace("'", "").replace("\n            ", "").trim();
    }

    if (contactType === "Natural person")
    {
        $(".TradeName_Info").hide();
        $(".Birthday_Info").show();
        $(".Gender_Info").show();
    }
    else if (contactType === "Legal person")
    {
        $(".TradeName_Info").show();
        $(".Birthday_Info").hide();
        $(".Gender_Info").hide();
    }
}

function changeLabel(contactType)
{
    if (contactType === undefined) {
        contactType = $("#ContactTypeValue").first().text().replace("'", "").replace("\n            ", "").trim();
    }

    if (contactType === "Natural person") {
        $(".MainNameLabel").text("Name");
        $(".DocumentNumberLabel").text("CPF");
    }
    else if (contactType === "Legal person") {
        $(".MainNameLabel").text("Company Name");
        $(".DocumentNumberLabel").text("CNPJ");
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
    displayInformation($("input[name='ContactType']:checked").val());
    changeLabel($("input[name='ContactType']:checked").val());
}

$(document).ready(function () {    
    $("input[name='ContactType']").click(function () {
        displayInformation($(this).val());
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