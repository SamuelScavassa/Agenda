
export function validarSenha() {
    var um = document.getElementById("cadastroSenhaUm").value;
    var dois = document.getElementById("cadastroSenhaDois").value;
    if (um == dois) {
        return true
    } else {
        alert("As senhas não correspondem")
        return false
    }
}

