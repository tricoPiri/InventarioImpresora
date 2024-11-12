// Class definition
var validation;
var KTFormControls = function () {
	// Private functions
	var _initDemo1 = function () {
		validation = FormValidation.formValidation(
			document.getElementById('kt_form_1'),
			{
				fields: {
					Nombres: {
						validators: {
							notEmpty: {
								message: 'El nombre (s) es requerido'
							}
						}
					},
					ApellidoPaterno: {
						validators: {
							notEmpty: {
								message: 'El apellido paterno es requerido'
							}
						}
					},
					ApellidoMaterno: {
						validators: {
							notEmpty: {
								message: 'El apellido materno es requerido'
							}
						}
					},
					Usuario: {
						validators: {
							notEmpty: {
								message: 'El usuario es requerido'
							}
						}
					},
					Password: {
						validators: {
							notEmpty: {
								message: 'La contrase&ntilde;a es requerido'
							}
						}
					},
					Rol: {
						validators: {
							notEmpty: {
								message: 'El rol es requerido'
							}
						}
					}
				},

				plugins: { //Learn more: https://formvalidation.io/guide/plugins
					trigger: new FormValidation.plugins.Trigger(),
					// Bootstrap Framework Integration
					//bootstrap: new FormValidation.plugins.Bootstrap(),
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

function validarCampos()
{	
	validation.validate().then(function (status) {
		if (status == 'Valid')
		{
			registrarHijo()
			
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
