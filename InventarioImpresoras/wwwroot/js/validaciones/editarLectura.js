// Class definition
var validation;
var KTFormControls = function () {
	// Private functions
	var _initDemo1 = function () {
		validation = FormValidation.formValidation(
			document.getElementById('kt_form_1'),
			{
				fields: {
					FechaLectura: {
						validators: {
							notEmpty: {
								message: 'La fecha de lectura es requerido'
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
					Impresora: {
						validators: {
							notEmpty: {
								message: 'La impresora es requerido'
							}
						}
					},
					Marca: {
						validators: {
							notEmpty: {
								message: 'La marca es requerida'
							}
						}
					},
					Modelo: {
						validators: {
							notEmpty: {
								message: 'El modelo es requerido'
							}
						}
					},
					LecturaAnterior: {
						validators: {
							notEmpty: {
								message: 'La lectura anterior es requerido'
							}
						}
					},
					LecturaActual: {
						validators: {
							notEmpty: {
								message: 'La lectura actual es requerido'
							}
						}
					},
					LecturaActual: {
						validators: {
							notEmpty: {
								message: 'La lectura actual es requerido'
							}
						}
					},
					CopiasProcesadas: {
						validators: {
							notEmpty: {
								message: 'El n&uacute;mero de copias procesadas es requerido'
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

function validarCampos(insertar)
{	
	validation.validate().then(function (status) {
		if (insertar == true)
		{
			if (status == 'Valid') {
				registrarLectura()

			} 
		}
	})
}
jQuery(document).ready(function() {
	KTFormControls.init();
});
