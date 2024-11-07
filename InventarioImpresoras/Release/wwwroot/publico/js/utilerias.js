var hostname = window.location.href
var posicionProtocolo = 0
var posicionDominio = 2

var ultimoCaracter = hostname.charAt(hostname.length - 1);

if (ultimoCaracter == "/") {
    hostname = hostname.slice(0, -1);
}

var urlSplit = hostname.split("/")
var urlSimplificado = urlSplit[posicionProtocolo] + "//" + urlSplit[posicionDominio]
