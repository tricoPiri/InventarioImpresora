// Class definition
var validation;
var KTFormControls = function () {
	// Private functions
	var _initDemo1 = function () {
		validation = FormValidation.formValidation(
			document.getElementById('kt_form_1'),
			{
				fields: {
					Empleado: {
						validators: {
							notEmpty: {
								message: 'El empleado es requerido'
							}
						}
					},
					NombreConyugue: {
						validators: {
							notEmpty: {
								message: 'El nombre del conyugue es requerido'
							}
						}
					},
					FechaMatrimonio: {
						validators: {
							notEmpty: {
								message: 'La fecha de matrimonio es requerido'
							}
						}
					},
					TelefonoConyugue: {
						validators: {
							notEmpty: {
								message: 'El tel&eacute;fono conyugue es requerido'
							}
						}
					},
					Nivel: {
						validators: {
							notEmpty: {
								message: 'El nivel es requerido'
							}
						}
					},
					NumeroHijos: {
						validators: {
							notEmpty: {
								message: 'El n&uacute;mero de hijos es requerido'
							}
						}
					}
				},

				plugins: { //Learn more: https://formvalidation.io/guide/plugins
					trigger: new FormValidation.plugins.Trigger(),
					// Bootstrap Framework Integration
					bootstrap: new FormValidation.plugins.Bootstrap(),
					// Validate fields when clicking the Submit button
					submitButton: new FormValidation.plugins.SubmitButton(),
            		// Submit the form when all fields are valid
            		//defaultSubmit: new FormValidation.plugins.DefaultSubmit(),
				}
			}
		);
	}
	
	return {
		// public functions
		init: function() {
			_initDemo1();
		}
	};
}();

function editarFamiliaConyugue()
{	
	validation.validate().then(function (status) {
		if (status == 'Valid')
		{
			//INICIO DESPUES KITAR
			     swal.fire({
			         icon: "success",
			         buttonsStyling: false,
			         confirmButtonText: "Ok!",
			         title: "Registro editado con &eacutexito!",
			         customClass: {
			             confirmButton: "btn font-weight-bold btn-light-primary"
			         }
			     }).then(function () {
			         KTUtil.scrollTop();
			     });
			     setTimeout(function () {
					 window.location.href = '/Familia/ViewIndexConyugue';
			     }, 2000)
			//FINAL DESPUES KITAR
			//$.ajax({
			//	url: "/Usuario/Agregar",
			//	data: { nombre: $("#txtNombre").val(), apellidoPaterno: $("#txtPaterno").val(), apellidoMaterno: $("#txtMaterno").val(), telefono: $("#txtTelefono").val(), correo: $("#txtCorreo").val(), rolId: 5, idTratamiento: $("#dropTratamiento").val(), idCargo: $("#dropCargo").val(), idArea: $("#dropArea").val() },
			//	type: "POST",
			//	success: function (response) {
			//		if (response.item1 == "Correo") {
			//			swal.fire({
			//				icon: "warning",
			//				buttonsStyling: false,
			//				confirmButtonText: "Ok!",
			//				title: "Error al registrar!",
			//				text: "El correo " + swalMensaje + " ya esta registrado con otro usuario!",
			//				customClass: {
			//					confirmButton: "btn font-weight-bold btn-light-primary"
			//				}
			//			}).then(function () {
			//				KTUtil.scrollTop();
			//			});

			//		} else if (response.item1 == "Error") {
			//			swal.fire({
			//				icon: "error",
			//				buttonsStyling: false,
			//				confirmButtonText: "Ok!",
			//				title: "Error al registrar el usuario!",
			//				customClass: {
			//					confirmButton: "btn font-weight-bold btn-light-primary"
			//				}
			//			}).then(function () {
			//				KTUtil.scrollTop();
			//			});

			//		} else if (response.item1 == "ErrorEnvioCorreo") {
			//			swal.fire({
			//				icon: "error",
			//				buttonsStyling: false,
			//				confirmButtonText: "Ok!",
			//				title: "Error al enviar correo electr&oacute;nico!",
			//				customClass: {
			//					confirmButton: "btn font-weight-bold btn-light-primary"
			//				}
			//			}).then(function () {
			//				KTUtil.scrollTop();
			//			});
			//		} else if (response.item1 == "Respuesta" && response.item2 > 0) {
			//			swal.fire({
			//				icon: "success",
			//				buttonsStyling: false,
			//				confirmButtonText: "Ok!",
			//				title: "Usuario registrado con &eacute;xito!",
			//				customClass: {
			//					confirmButton: "btn font-weight-bold btn-light-primary"
			//				}
			//			}).then(function () {
			//				KTUtil.scrollTop();
			//			});
			//		} else {
			//			swal.fire({
			//				icon: "error",
			//				buttonsStyling: false,
			//				confirmButtonText: "Ok!",
			//				title: "Error al registrar el usuario!",
			//				customClass: {
			//					confirmButton: "btn font-weight-bold btn-light-primary"
			//				}
			//			}).then(function () {
			//				KTUtil.scrollTop();
			//			});
			//		}
			//	}
			//})
		} else {
			Swal.fire({
				title: "Debes de capturar los campos obligatorios!",
				icon: "warning",
				buttonsStyling: false,
				confirmButtonText: "Ok!",
				customClass: {
					confirmButton: "btn font-weight-bold btn-light"
				}
			}).then(function () {
				KTUtil.scrollTop();
			});
		}
	})
}
jQuery(document).ready(function() {
	KTFormControls.init();
});
