"use strict";
var contadorArchivos = 0
var KTDropzoneDemo = function () {
    var demo2 = function () {
        var id = '#kt_dropzone_3';
        var previewNode = $(id + " .dropzone-item");
        previewNode.id = "";
        var previewTemplate = previewNode.parent('.dropzone-items').html();
        previewNode.remove();
        myDropzone4 = new Dropzone(id, {
            url: urlSimplificado + "/DocumentoNotificacion/RegistrarDocumentos",
            paramName: "file",
            maxFiles: null,
            maxFilesize: 256,
            //maxFilesize: 1024,
            addRemoveLinks: true,
            acceptedFiles: "image/*,application/pdf,.psd",
            autoProcessQueue: false,
            parallelUploads: 20,
            //timeout: 300000,
            timeout: null,
            accept: function (file, done) {
                done();
            }
        });

        myDropzone4.on("addedfile", function (file) {
            validarDropzone()
            console.log("addedfile: \n")
            /*
            file.previewElement.querySelector(id + " .dropzone-start").onclick = function () { myDropzone4.enqueueFile(file); };
            $(document).find(id + ' .dropzone-item').css('display', '');
            $(id + " .dropzone-upload, " + id + " .dropzone-remove-all").css('display', 'inline-block');
            */
        });

        myDropzone4.on("totaluploadprogress", function (progress) {
            console.log("totaluploadprogress: \n")
            console.log(progress)
            //$(this).find(id + " .progress-bar").css('width', progress + "%");
        });

        myDropzone4.on("sending", function (file, xhr, formData) {
            console.log("en sending: \n")
            console.log("idNotificacion: " + $("#txtNotificacionId").val())
            formData.append("idNotificacion", $("#txtNotificacionId").val())
            /*
            $(id + " .progress-bar").css('opacity', '1');
            // And disable the start button
            file.previewElement.querySelector(id + " .dropzone-start").setAttribute("disabled", "disabled");
            */
        });

        myDropzone4.on("complete", function (progress) {
            console.log("complete: \n")
            /*
            var thisProgressBar = id + " .dz-complete";
            setTimeout(function () {
                $(thisProgressBar + " .progress-bar, " + thisProgressBar + " .progress, " + thisProgressBar + " .dropzone-start").css('opacity', '0');
            }, 300)
            */
        });

        myDropzone4.on("success", function (file, response) {
            console.log("success: \n")
            contadorArchivos = contadorArchivos + 1
            if (response == "1") {
                if (myDropzone4.files.length == contadorArchivos) {
                    $.ajax({
                        url: "/Correo/EnviarCorreo",
                        data: { correoReceptor: $("#txtCorreo").val(), sujetoObligado: $("#txtSujetObligado").val(), enteFiscalizable: $("#dropEnteFiscalizable option:selected").text() },
                        type: "POST",
                        success: function (response) {
                            if (response == true) {
                                Swal.fire({
                                    title: "Notificaci&oacute;n enviada con &eacute;xito!",
                                    icon: "success",
                                    buttonsStyling: false,
                                    confirmButtonText: "Ok",
                                    customClass: {
                                        confirmButton: "btn font-weight-bold btn-light"
                                    }
                                }).then(function () {
                                    //KTUtil.scrollTop();
                                });
                            } else {
                                Swal.fire({
                                    title: "Ocurri&oacute; un error!",
                                    text: "Contacte a su administrador.",
                                    icon: "error",
                                    buttonsStyling: false,
                                    confirmButtonText: "Ok",
                                    customClass: {
                                        confirmButton: "btn font-weight-bold btn-light"
                                    }
                                }).then(function () {
                                    //KTUtil.scrollTop();
                                });
                            }
                        }
                    })
                }

            } else {
                Swal.fire({
                    title: "Ocurri&oacute; un error!",
                    text: "Contacte a su administrador.",
                    icon: "error",
                    buttonsStyling: false,
                    confirmButtonText: "Ok",
                    customClass: {
                        confirmButton: "btn font-weight-bold btn-light"
                    }
                }).then(function () {
                    //KTUtil.scrollTop();
                });
            }

        })

        myDropzone4.on("removedfile", function (file) {
            console.log("removedfile")
           validarDropzone()
            /*
            let nombreArchivo = file.name
            $.ajax({
                url: "/Documento/EliminarArchivo",
                data: { nombreArchivo: nombreArchivo },
                type: "POST",
                success: function (response) {
                }
            })
            */
        });

        // Setup the buttons for all transfers
        //document.querySelector(id + " .dropzone-upload").onclick = function () {

        //myDropzone4.enqueueFiles(myDropzone4.getFilesWithStatus(Dropzone.ADDED));
    };

    // Setup the button for remove all files
    //document.querySelector(id + " .dropzone-remove-all").onclick = function () {
    //    /*
    //    $(id + " .dropzone-upload, " + id + " .dropzone-remove-all").css('display', 'none');
    //    myDropzone4.removeAllFiles(true);
    //    */
    //};

    // On all files completed upload
    //myDropzone4.on("queuecomplete", function (progress) {
    //    //$(id + " .dropzone-upload").css('display', 'none');
    //});

    // On all files removed
    //myDropzone4.on("removedfile", function (file) {
    //    /*
    //    if (myDropzone4.files.length < 1) {
    //        $(id + " .dropzone-upload, " + id + " .dropzone-remove-all").css('display', 'none');
    //    }
    //    */
    //});
    //}

    return {
        init: function () {
            demo2();
        }
    };
}();

KTUtil.ready(function () {
    KTDropzoneDemo.init();
});

