// Class definition
var validation;
var KTFormControls = function () {
	// Private functions
	var _initDemo1 = function () {
		validation = FormValidation.formValidation(
			document.getElementById('kt_form_1'),
			{
				fields: {
					NumeroEmpleado: {
						validators: {
							notEmpty: {
								message: 'El n&uacute;mero de empleado es requerido'
							}
						}
					},
					FechaIngreso: {
						validators: {
							notEmpty: {
								message: 'La fecha de ingreso es requerido'
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
					Plaza: {
						validators: {
							notEmpty: {
								message: 'La plaza es requerido'
							}
						}
					},
					Area: {
						validators: {
							notEmpty: {
								message: 'El &aacute;rea es requerido'
							}
						}
					},
					SubArea: {
						validators: {
							notEmpty: {
								message: 'La sub &aacute;rea es requerido'
							}
						}
					},
					Puesto: {
						validators: {
							notEmpty: {
								message: 'El puesto es requerido'
							}
						}
					}
				},

				plugins: { //Learn more: https://formvalidation.io/guide/plugins
					trigger: new FormValidation.plugins.Trigger(),
					// Bootstrap Framework Integration
					bootstrap: new FormValidation.plugins.Bootstrap({
						eleInvalidClass: '',
						//eleValidClass: '',
					}),
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

function agregarExpedienteEmpleado()
{	
	validation.validate().then(function (status) {
		if (status == 'Valid')
		{
			registrarContratoEmpleado()
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
