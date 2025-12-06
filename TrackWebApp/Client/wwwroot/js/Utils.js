function confirmar(title, text, icon) {
    return new Promise(resolve => {
        Swal.fire({
            title,
            text,
            icon,
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Confirmar!'
        }).then((result) => {
            resolve(result.isConfirmed)
        })
    })
}
var timer;
function timerInactivo(dotnetHelper) {
    
    document.onmousemove = resetTimer;
    document.onkeypress = resetTimer;

    function resetTimer() {
        clearTimeout(timer);
        timer = setTimeout(logout,300000);
    }
    function logout() {
        dotnetHelper.invokeMethodAsync("LogOut")
    }
}