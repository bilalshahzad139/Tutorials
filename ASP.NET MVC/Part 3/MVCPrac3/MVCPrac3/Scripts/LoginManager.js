
window.onload = function () {
    var btn = document.getElementById('btnLogin');
    btn.onclick = Validate;
}

function Validate() {
    var login = document.getElementById('txtLogin');
    var pswd = document.getElementById('txtPassword');

    if(login.value == '')
    {
        alert('Login cant be empty!');
        return false;
    }
    if (pswd.value == '') {
        alert('Login cant be empty!');
        return false;
    }
}