"use strict";
// Class definition
var validacionTabProfesion = false
var contadorTabProfesion = 0
var respuesta = null
//var empleado_id = null
var KTWizard4 = function () {
	// Base elements
	var _wizardEl;
	var _formEl;
	var _wizardObj;
	var _validations = [];

	// Private functions
	var _initWizard = function () {
		// Initialize form wizard
		_wizardObj = new KTWizard(_wizardEl, {
			startStep: 0, // initial active step number
			clickableSteps: false  // allow step clicking
		});

		// Validation before going to next page
		_wizardObj.on('change', function (wizard) {
			if (wizard.getStep() > wizard.getNewStep()) {
				return; // Skip if stepped back
			}

			// Validate form before change wizard step
			var validator = _validations[wizard.getStep() - 1]; // get validator for currnt step

			if (validator) {
				validator.validate().then(function (status) {
					
					let estatusTabProfesion = $("#tabProfesion").attr("data-wizard-state")
					if ($("#tabProfesion").attr("data-wizard-state") == 'current') {
						contadorTabProfesion = contadorTabProfesion + 1
						if (contadorTabProfesion >= 1) {
							contadorTabProfesion = 0
						}
						if (contadorTabProfesion == 0) {
							//validacion si tiene titulo
							if ($('input[name="radioTitulo"]:checked').val() == null) {
								validacionTabProfesion = false
								$("#msjValidadorTitulo").show()
							}
							else {
								$("#msjValidadorTitulo").hide()
								$("#msjValidadorCarreraTrunca").hide()
								//$("#txtCarreraTrunca").css("border-color", "#E4E6EF")
								if ($('input[name="radioTitulo"]:checked').val() == true) {
									//If convinacion 1
									if ($("#dropProfesion").val() != '' && $('input[name="radioPosgrado"]:checked').val() == true && $("#dropPosgrado").val() != '') {
										validacionTabProfesion = true
										$("#msjValidadorProfesion").hide()
										$("#msjValidadorPosgrado").hide()
									} else {
										if ($("#dropProfesion").val() == '') {
											$("#msjValidadorProfesion").show()
											$("#dropProfesion").css("border-color", "#F64E60")
										} else {
											$("#msjValidadorProfesion").hide()
											$("#dropProfesion").css("border-color", "#E4E6EF")
										}

										$('input[name="radioPosgrado"]:checked').val() == null ? $("#msjValidadorRadioPosgrado").show() : $("#msjValidadorRadioPosgrado").hide()

										if ($('input[name="radioPosgrado"]:checked').val() == true) {
											if ($("#dropPosgrado").val() == '') {
												$("#dropPosgrado").css("border-color", "#F64E60")
												$("#msjValidadorPosgrado").show()
											} else {
												$("#dropPosgrado").css("border-color", "#E4E6EF")
												$("#msjValidadorPosgrado").hide()
											}
										} else {
											$("#msjValidadorPosgrado").hide()
										}
										//If convinacion 3
										if ($('input[name="radioTitulo"]:checked').val() == true && $("#dropProfesion").val() != '' && $('input[name="radioPosgrado"]:checked').val() == false && $('input[name="radioEstudiandoPosgrado"]:checked').val() == false) {

											validacionTabProfesion = true
										} else {
											validacionTabProfesion = false
											//If convinacion 4
											if ($('input[name="radioTitulo"]:checked').val() == true && $("#dropProfesion").val() != '' && $('input[name="radioPosgrado"]:checked').val() == false && $('input[name="radioEstudiandoPosgrado"]:checked').val() == true && $("#txtCursoPosgrado").val() != '') {
												validacionTabProfesion = true
												$("#msjValidadorEstudiandoPosgrado").hide()
											} else {
												$('input[name="radioEstudiandoPosgrado"]:checked').val() == null ? $("#msjValidadorEstudiandoPosgrado").show() : $("#msjValidadorEstudiandoPosgrado").hide()
												if ($('#txtCursoPosgrado').val() == '') {
													//$("#txtCursoPosgrado").css("border-color", "#F64E60")
													$("#msjValidadorCursoPosgrado").show()
												} else {
													//$("#txtCursoPosgrado").css("border-color", "#E4E6EF")
													$("#msjValidadorCursoPosgrado").hide()
												}
												validacionTabProfesion = false
											}
										}
									}
								}
								else if ($('input[name="radioTitulo"]:checked').val() == false) {
									$("#msjValidadorProfesion").hide()
									$("#msjValidadorRadioPosgrado").hide()
									$("#msjValidadorPosgrado").hide()

									//If convinacion 2
									if ($("#txtCarreraTrunca").val() != '') {
										//$("#txtCarreraTrunca").css("border-color", "#E4E6EF")
										$("#msjValidadorCarreraTrunca").hide()
										validacionTabProfesion = true
									} else {
										//$("#txtCarreraTrunca").css("border-color", "#F64E60")
										$("#msjValidadorCarreraTrunca").show()
										validacionTabProfesion = false
									}
								}
							}
						}
					}

					if ($("#tabProfesion").attr("data-wizard-state") == 'pending') {
						contadorTabProfesion = 0
					}

					if (estatusTabProfesion == 'current' && validacionTabProfesion == true || (estatusTabProfesion == 'pending' || estatusTabProfesion == 'done')) {
						if (status == 'Valid') {
							wizard.goTo(wizard.getNewStep());
							KTUtil.scrollTop();
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
						
					});
			}
			return false;  // Do not change wizard step, further action will be handled by he validator
		});

		// Change event
		_wizardObj.on('changed', function (wizard) {
			KTUtil.scrollTop();
		});

		// Submit event
		_wizardObj.on('submit', function (wizard) {
		});
	}

	var _initValidation = function () {
		// Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
		// Step 1
		_validations.push(FormValidation.formValidation(
			_formEl,
			{
				fields: {
					Nombre: {
						validators: {
							notEmpty: {
								message: 'El nombre es requerido'
							}
						}
					},
					ApellidoPaterno: {
						validators: {
							notEmpty: {
								message: 'El apellido paterno es requerido'
							}
						}
					},/*
					ApellidoMaterno: {
						validators: {
							notEmpty: {
								message: 'El apellido materno es requerido'
							}
						}
					},*/
					FechaNacimiento: {
						validators: {
							notEmpty: {
								message: 'La fecha de nacimiento es requerido'
							}
						}
					},
					RFC: {
						validators: {
							notEmpty: {
								message: 'El RFC es requerido'
							},
							stringLength: {
								min: 13,
								max: 13,
								message: 'El RFC debe de constar de trece caracteres'
							}
						}						
					},
					Curp: {
						validators: {
							notEmpty: {
								message: 'La CURP es requerido'
							},
							stringLength: {
								min: 18,
								max: 18,
								message: 'La CURP debe de constar de dieciocho caracteres'
							}
						}
					},
					Genenero: {
						validators: {
							notEmpty: {
								message: 'El g&eacute;nero es requerido'
							}
						}
					},/*
					TipoSangre: {
						validators: {
							notEmpty: {
								message: 'El tipo de sangre es requerido'
							}
						}
					},*//*
					EstadoCivil: {
						validators: {
							notEmpty: {
								message: 'El estado civil es requerido'
							}
						}
					}
					*/
				},
				plugins: {
					trigger: new FormValidation.plugins.Trigger(),
					// Bootstrap Framework Integration
					bootstrap: new FormValidation.plugins.Bootstrap({
						eleInvalidClass: '',
						//eleValidClass: '',
					})
				}
			}
		));

		// Step 2
		_validations.push(FormValidation.formValidation(
			_formEl,
			{
				fields: {
					CalleOriginal: {
						validators: {
							notEmpty: {
								message: 'La calle es requerida'
							}
						}
					},
					/*
					EntreCalles: {
						validators: {
							notEmpty: {
								message: 'Entre calles es requerido'
							}
						}
					},
					*/
					NumeroExterior: {
						validators: {
							notEmpty: {
								message: 'N&uacute;mero exterior es requerido'
							}
						}
					},/*
					NumeroInterior: {
						validators: {
							notEmpty: {
								message: 'El n&uacute;mero interior es requerida'
							}
						}
					},
					*/
					Colonia: {
						validators: {
							notEmpty: {
								message: 'La colonia es requerida'
							}
						}
					},
					CodigoPostal: {
						validators: {
							notEmpty: {
								message: 'El c&oacute;digo postal es requerido'
							}
						}
					}
				},
				plugins: {
					trigger: new FormValidation.plugins.Trigger(),
					// Bootstrap Framework Integration
					bootstrap: new FormValidation.plugins.Bootstrap({
						eleInvalidClass: '',
						//eleValidClass: '',
					})
				}
			}
		));
		
		// Step 3
		_validations.push(FormValidation.formValidation(
			_formEl,
			{
				fields: {
				},
				plugins: {
					trigger: new FormValidation.plugins.Trigger(),
					// Bootstrap Framework Integration
					bootstrap: new FormValidation.plugins.Bootstrap({
						eleInvalidClass: '',
						//eleValidClass: '',
					})
				}
			}
		));

		// Step 4
		_validations.push(FormValidation.formValidation(
			_formEl,
			{
				fields: {
					CorreoElectronicoPersonal: {
						validators: {
							notEmpty: {
								message: 'El correo electr&oacute;nico es requerido'
							},
							emailAddress: {
								message: 'Ingrese un correo electr&oacute;nico valido'
							}
						}
					},
					txtCorreoElectronicoInstitucional: {
						validators: {
							notEmpty: {
								message: 'El correo electr&oacute;nico es requerido'
							},
							emailAddress: {
								message: 'Ingrese un correo electr&oacute;nico valido'
							}
						}
					},
					TelefonoMovil: {
						validators: {
							notEmpty: {
								message: 'El tel&eacute;fono movil es requerido'
							}
						}
					}/*,
					TelefonoCasa: {
						validators: {
							notEmpty: {
								message: 'El tel&eacute;fono de casa es requerido'
							}
						}
					}
					*/
				},
				plugins: {
					trigger: new FormValidation.plugins.Trigger(),
					// Bootstrap Framework Integration
					bootstrap: new FormValidation.plugins.Bootstrap({
						eleInvalidClass: '',
						//eleValidClass: '',
					})
				}
			}
		));

		//	Step 5
		_validations.push(FormValidation.formValidation(
			_formEl,
			{
				fields: {
					radioTieneHijos: {
						validators: {
							choice: {
								min: 1,
								message: 'Seleccione si tiene hijos o no'
							}
						}
					},
					EstadoCivil: {
						validators: {
							notEmpty: {
								message: 'El estado civil es requerido'
							}
						}
					},
					FamiliaresGobiernoEstado: {
						validators: {
							notEmpty: {
								message: 'Especifique si tiene familiares trabajando en gobierno del estado'
							}
						}
					}
				},
				plugins: {
					trigger: new FormValidation.plugins.Trigger(),
					// Bootstrap Framework Integration
					bootstrap: new FormValidation.plugins.Bootstrap({
						eleInvalidClass: '',
						//eleValidClass: '',
					})
				}
			}
		));
		
	}

	return {
		// public functions
		init: function () {
			_wizardEl = KTUtil.getById('kt_wizard');
			_formEl = KTUtil.getById('kt_form');

			_initWizard();
			_initValidation();
		}
	};
}();

jQuery(document).ready(function () {
	KTWizard4.init();
});
