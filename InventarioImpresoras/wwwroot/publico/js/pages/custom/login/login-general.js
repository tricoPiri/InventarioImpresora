"use strict";

var validation;

// Class Definition
var KTLogin = function () {
    var _login;
    var _showForm = function (form) {
        var cls = 'login-' + form + '-on';
        var form = 'kt_login_' + form + '_form';

        _login.removeClass('login-signin-on');
        _login.addClass(cls);

        KTUtil.animateClass(KTUtil.getById(form), 'animate__animated animate__backInUp');
    }

    var _handleSignInForm = function () {
        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validation = FormValidation.formValidation(
            KTUtil.getById('kt_login_signin_form'),
            {
                fields: {
                    Usuario: {
                        validators: {
                            notEmpty: {
                                message: 'El usuario es requerido.'
                            }
                        }
                    },
                    Password: {
                        validators: {
                            notEmpty: {
                                message: 'La contrase&ntilde;a es requerida.'
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    submitButton: new FormValidation.plugins.SubmitButton(),
                    //defaultSubmit: new FormValidation.plugins.DefaultSubmit(), // Uncomment this line to enable normal button submit after form validation
                    bootstrap: new FormValidation.plugins.Bootstrap()
                }
            }
        );
    }

    return {
        // public functions
        init: function () {
            _login = $('#kt_login');
            _handleSignInForm();
        }
    };

}();

function loguearse() {

    var urlLogin = hostname.split("/")
    let posicionProtocolo = 0
    let posicionDominio = 2
    let urlLoginProcesado = null

    urlLoginProcesado = urlLogin[posicionProtocolo] + "//" + urlLogin[posicionDominio]

    validation.validate().then(function (status) {
        if (status == 'Valid') {
            $.ajax({
                url: urlLoginProcesado + '/Login/Login',
                data: { usuario: $("#usuario").val(), contrasena: $("#password").val() },
                type: "POST",
                success: function (response) {
                    if (response == "1") {

                        window.location.href = urlLoginProcesado + "/Empleado/Index"

                    } else if (response == "2") {

                        window.location.href = urlLoginProcesado + "/Empleado/Index"

                    } else if (response == "3") {

                        window.location.href = urlLoginProcesado + "/Empleado/Index"

                    } else if (response == "4") {

                        window.location.href = urlLoginProcesado + "/Afiliacion/Index"

                    } else {
                        swal.fire({
                            title: "Ingrese un usuario y contrase&ntilde;a validos.",
                            icon: "error",
                            buttonsStyling: false,
                            confirmButtonText: "Ok!",
                            customClass: {
                                confirmButton: "btn font-weight-bold btn-light-primary"
                            }
                        }).then(function () {
                            KTUtil.scrollTop();
                        });
                    }
                }
            })
        }
    });
}

// Class Initialization
jQuery(document).ready(function () {
    KTLogin.init();
});