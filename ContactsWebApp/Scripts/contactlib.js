function displayFrame(inputName)
{
    if (inputName === "Natural person") {
        $("#TradeName_Div").hide();
        $("#Birthday_Div").show();
        $("#Gender_Div").show();
        $("label[for*='MainName']").text("Name");
        $("label[for*='DocumentNumber']").text("CPF");
    }
    if (inputName === "Legal person") {
        $("#TradeName_Div").show();
        $("#Birthday_Div").hide();
        $("#Gender_Div").hide();
        $("label[for*='MainName']").text("Company Name");
        $("label[for*='DocumentNumber']").text("CNPJ");
    }
}

window.onload = function () {
    displayFrame($("input[name='ContactType']:checked").val());
}

$(document).ready(function () {    
    $("input[name='ContactType']").click(function () {
        displayFrame($(this).val());
    });
});