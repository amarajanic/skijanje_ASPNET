// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

////var dateNow = Date.now();

////document.getElementById("datumPocetak").defaultValue = Date.now();

////document.getElementById("datumKraj").defaultValue = dateNow.setDate(dateNow.getDate() + 6);

$.validator.addMethod(
    "regex",
    function (value, element, regexp) {
        var check = false;
        return this.optional(element) || regexp.test(value);
    },
    "Please check your input."
);

$("#instruktorDodaj").validate({
    rules: {
        ime: {
            required: true,
            regex: /^[A-Z][a-zA-Z ]+[A-Z][a-zA-Z]+$/
        },
        prezime: {
            required: true,
            regex: /^[A-Z][a-zA-Z ]+[A-Z][a-zA-Z]+$/
        },
        datRodj: {
            required: true
        },
        spol: {
            required: true
        },
        kontaktTel: {
            required: true,
            regex: /^\+[0-9]{3}-[0-9]{2}-[0-9]{3}-[0-9]{3}$/
        },
         skijIsk: {
            required: true
        },
        bio: {
            required: true,
            regex: /^[a-zA-Z]+$/
        },
        cv: {
            required: true
        }

    }
});

$("#ucenikDodaj").validate({
    rules: {
        ime: {
            required: true,
            regex: /^[A-Z][a-zA-Z ]+[A-Z][a-zA-Z]+$/
        },
        prezime: {
            required: true,
            regex: /^[A-Z][a-zA-Z ]+[A-Z][a-zA-Z]+$/
        },
        datRodj: {
            required: true
        },
        spol: {
            required: true
        },
        kontaktTel: {
            required: true,
            regex: /^\+[0-9]{3}-[0-9]{2}-[0-9]{3}-[0-9]{3}$/
        },
    }
});

$("#instrukcijaDodaj").validate({
    rules: {
        datum: {
            required: true
        },
        vrijeme: {
            required: true
        },
        brojCas: {
            required: true
        },
        instruktor: {
            required: true
        },
        biljeske: {
            required: true
        }
    }
});

