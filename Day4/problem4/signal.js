function signal() {

    let signal = document.getElementById("signalin").value;
    let message = "";

    switch(signal) {

        case "red":
            message = " PleaseStop";
            break;

        case "yellow":
            message = "Get Ready to go";
            break;

        case "green":
            message = "Go";
            break;

        default:
            message = "Invalid signal color";
    }

    document.getElementById("signalop").innerText = message;
}
