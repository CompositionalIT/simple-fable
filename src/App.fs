module App

open Browser.Dom

// Mutable variable to count the number of times we clicked the button
let mutable count = 0

// Get a reference to my-button (see ~/public/index.html)
let myButton = document.getElementById "my-button"

// Register our listener
myButton.onclick <- fun _ ->
    count <- count + 1
    myButton.innerText <- sprintf "You clicked: %i time(s)" count

    if count > 5 then
        window.alert (sprintf "%O: Please stop clicking me!" System.DateTime.UtcNow)