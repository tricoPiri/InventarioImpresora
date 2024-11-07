// Class definition
var validation;
var validationPenultimo;
var KTFormControls = function () {
	// Private functions
	var _initDemo1 = function () {
		validation = FormValidation.formValidation(
			document.getElementById('kt_form_1'),
			{
				fields: {
					PeriodoServicio: {
						validators: {
							notEmpty: {
								message: 'El periodo servicio es requerido'
							}
						}
					},
					NombreEmpresa: {
						validators: {
							notEmpty: {
								message: 'El nombre de la empresa es requerido'
							}
						}
					},
					/*
					Telefono: {
						validators: {
							notEmpty: {
								message: 'El tel&eacutefono de la empresa es requerido'
							}
						}
					},
					*/
					PuestoDesempenado: {
						validators: {
							notEmpty: {
								message: 'El puesto desempe&ntildeado es requerido'
							}
						}
					},
					SueldoInicial: {
						validators: {
							notEmpty: {
								message: 'El sueldo inicial es requerido'
							}
						}
					},
					SueldoFinal: {
						validators: {
							notEmpty: {
								message: 'El sueldo final es requerido'
							}
						}
					},
					MotivoSeparacion: {
						validators: {
							notEmpty: {
								message: 'La motivacion de separaci&oacuten es requerido'
							}
						}
					},
					JefeInmediato: {
						validators: {
							notEmpty: {
								message: 'El nombre del jefe inmediato es requerido'
							}
						}
					},
					PuestoJefeInmediato: {
						validators: {
							notEmpty: {
								message: 'El puesto del jefe inmediato es requerido'
							}
						}
					},
					radioReferencias: {
						validators: {
							choice: {
								min: 1,
								message: 'Seleccione si podemos solicitar referencias o no'
							}
						}
					},
					//FINAL
					/*
					radios3: {
						validators: {
							notEmpty: {
								message: 'El nombre de la empresa es requerido'
							}
						}
					},
					*/
					//FINAL
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
	//INICIO
	var _initDemo2 = function () {
		validationPenultimo = FormValidation.formValidation(
			document.getElementById('kt_form_2'),
			{
				fields: {
					PeriodoServicioPenultimo: {
						validators: {
							notEmpty: {
								message: 'El periodo servicio es requerido'
							}
						}
					},
					NombreEmpresaPenultimo: {
						validators: {
							notEmpty: {
								message: 'El nombre de la empresa es requerido'
							}
						}
					},
					/*
					TelefonoPenultimo: {
						validators: {
							notEmpty: {
								message: 'El tel&eacutefono de la empresa es requerido'
							}
						}
					},
					*/
					PuestoDesempenadoPenultimo: {
						validators: {
							notEmpty: {
								message: 'El puesto desempe&ntildeado es requerido'
							}
						}
					},
					SueldoInicialPenultimo: {
						validators: {
							notEmpty: {
								message: 'El sueldo inicial es requerido'
							}
						}
					},
					SueldoFinalPenultimo: {
						validators: {
							notEmpty: {
								message: 'El sueldo final es requerido'
							}
						}
					},
					MotivoSeparacionPenultimo: {
						validators: {
							notEmpty: {
								message: 'La motivacion de separaci&oacuten es requerido'
							}
						}
					},
					JefeInmediatoPenultimo: {
						validators: {
							notEmpty: {
								message: 'El nombre del jefe inmediato es requerido'
							}
						}
					},
					PuestoJefeInmediatoPenultimo: {
						validators: {
							notEmpty: {
								message: 'El puesto del jefe inmediato es requerido'
							}
						}
					},
					radioReferenciasPenultimo: {
						validators: {
							choice: {
								min: 1,
								message: 'Seleccione si podemos solicitar referencias o no'
							}
						}
					},
					//FINAL
					/*
					radios3: {
						validators: {
							notEmpty: {
								message: 'El nombre de la empresa es requerido'
							}
						}
					},
					*/
					//FINAL
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
	//FINAL
	
	return {
		// public functions
		init: function() {
			_initDemo1();
			_initDemo2();
		}
	};
}();

function validarCampos()
{	
	validation.validate().then(function (status) {
		if (status == 'Valid')
		{
			//alert("si son validos los campos")
			//registrarAfiliacionEmpleado()
			registrarUltimoEmpleo()

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
function validarCamposPenultimo() {
	validationPenultimo.validate().then(function (status) {
		if (status == 'Valid') {
			//alert("si son validos los campos")
			//registrarAfiliacionEmpleado()
			registrarPenultimoEmpleo()

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
