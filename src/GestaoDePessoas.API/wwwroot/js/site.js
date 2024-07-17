// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function verificarSenha(campo1, campo2) {
    var senha = document.getElementById(campo1).value;
    var senha2 = document.getElementById(campo2).value;

    if (senha.length < 8 || senha2.length < 8) {
        alert("A senha precisa ter no mínimo 8 (oito) caracteres");
        return false;
    }

    else if (senha !== senha2) {
        alert("As senhas não combinam");
        return false;
    }
    else {
        return true;
    }
}