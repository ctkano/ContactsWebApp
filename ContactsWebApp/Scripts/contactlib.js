/*!
 * ContactsWebApp 
 * Contacts Front Library: v1.0.0.0
 * © 2021 - Cleyton Kano
 */

/**
 * Display/Hide Fields or Information according to the Contact Type selected
 * @param {any} contactType
 */
function displayInformation(contactType)
{
    // Used to set label at Details View
    // ============================================================
    if (contactType === undefined) {
        contactType = $("#ContactTypeValue").first().text().replace("'", "").replace("\n            ", "").trim();
    }

    // Check the Contact Type selected and display/hide fields 
    // or information
    // ============================================================
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

/**
 * Set label information according to the Contact Type selected
 * @param {any} contactType
 */
function changeLabel(contactType)
{
    // Used to set label at Details View
    // ============================================================
    if (contactType === undefined) {
        contactType = $("#ContactTypeValue").first().text().replace("'", "").replace("\n            ", "").trim();
    }

    // Check the Contact Type selected and set the correspondent label
    // ============================================================
    if (contactType === "Natural person") {
        $(".MainNameLabel").text("Name");
        $(".DocumentNumberLabel").text("CPF");
    }
    else if (contactType === "Legal person") {
        $(".MainNameLabel").text("Company Name");
        $(".DocumentNumberLabel").text("CNPJ");
    }
}

/**
 * Function to mask the Document Number field, according to the Contact Type selected and its document number pattern
 * @param {any} object
 */
function maskDocumentNumberInitializer(object)
{
    obj = object

    // Check the Contact Type selected and address the 
    // correct function
    // ============================================================
    if ($("input[name='ContactType']:checked").val() === "Natural person")
        mask = cpfPatternMask
    else if ($("input[name='ContactType']:checked").val() === "Legal person")
        mask = cnpjPatternMask

    // Calls the mediating mask function with timeout
    // ============================================================
    setTimeout("maskDocumentNumber()", 1)
}

/**
 * Mediating mask function to assign the corresponding one, according to the Contact Type selected and its document number pattern
 */
function maskDocumentNumber()
{
    obj.value = mask(obj.value)
}

/**
 * CNPJ Pattern Mask
 * @param {any} cnpj
 */
function cnpjPatternMask(cnpj)
{
    cnpj = cnpj.replace(/\D/g, "")
    cnpj = cnpj.replace(/^(\d{2})(\d)/, "$1.$2")
    cnpj = cnpj.replace(/^(\d{2})\.(\d{3})(\d)/, "$1.$2.$3")
    cnpj = cnpj.replace(/\.(\d{3})(\d)/, ".$1/$2")
    cnpj = cnpj.replace(/(\d{4})(\d)/, "$1-$2")
    return cnpj
}

/**
 * CPF Pattern Mask
 * @param {any} cpf
 */
function cpfPatternMask(cpf) {
    cpf = cpf.replace(/\D/g, "")
    cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2")
    cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2")
    cpf = cpf.replace(/(\d{3})(\d{1,2})$/, "$1-$2")
    return cpf
}

/*
 * Calls Display/Hide Fields/Information function and Label Changing function on page load
 */
window.onload = function () {
    displayInformation($("input[name='ContactType']:checked").val());
    changeLabel($("input[name='ContactType']:checked").val());
}

/*
 * Calls Display/Hide Fields/Information function and Label Changing function when the user click in the Contact Type radio button
 */
$(document).ready(function () {   
    
    // When the user click in the Contact Type radio button
    // ============================================================
    $("input[name='ContactType']").click(function () {
        displayInformation($(this).val());
        changeLabel($(this).val());
    });

});

/*
 * Set document number mask according to the the Contact Type current selection for each entered character or when the user clicks in the document number field
 */
$(document).ready(function () {

    // For each entered character in the document number field
    // ============================================================
    $("input[name='DocumentNumber']").keyup(function () {
        maskDocumentNumberInitializer(this);
    });

    // When the user clicks in the document number field
    // ============================================================
    $("input[name='DocumentNumber']").click(function () {
        maskDocumentNumberInitializer(this);
    });

});