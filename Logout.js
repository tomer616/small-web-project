function logout() {
    var req = new XMLHttpRequest();
    req.open("POST", "http://192.168.1.63:8000/weather/logout/", true);
    req.withCredentials = true;
    req.send();

    document.getElementById('log_form').style.display = '';
    document.getElementById('logged_user').style.display = 'none';
    document.getElementById('logout_button').style.display = 'none';
    document.getElementById('content').style.display = 'none';
    hide_error();
}