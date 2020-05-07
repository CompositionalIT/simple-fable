module App

open Browser.Dom

// Mutable variable to count the number of times we clicked the button
let mutable count = 0

// 2. Get a reference to my-button (see ~/public/index.html)
let myButton = document.getElementById "my-button"

// 3-5. Register our listener
myButton.onclick <- fun _ ->
    count <- count + 1
    myButton.innerText <- sprintf "You clicked: %i time(s)" count

    if count > 5 then
        window.alert (sprintf "%O: Please stop clicking me!" System.DateTime.UtcNow)

open Fable.Core
open Fable.Core.JsInterop
open Fable.Core.Util

// 6. Simple reference of a function in a module from an NPM package (upper-case)
// See https://www.npmjs.com/package/upper-case
// Notice that F# correctly infers the function uppercase to be
// string -> string from the usage two lines later!
let uppercase = import "upperCase" "upper-case"
let myText = document.getElementById "my-text"
myText.innerText <- uppercase "Hello"

// Or use some lower-level alternative like this:
[<Emit "upperCase($0)">]
let foo (x:string) : string = jsNative
console.log (foo "simple uppercase") // check the console output...

// You can do some pretty crazy stuff with Fable mixing JS's super
// weak runtime with F# on top!
[<Emit "$0 + $1">]
let addThroughJs (x: int) (y: int) = jsNative
console.log (addThroughJs 10 5)

// Look at this. We can add a number and a string together through
// JS. And then add another number to it. And it works, more or less!

[<Emit "$0 + $1">]
let addJsCrazy (x: int) (y: string) : int = jsNative
console.log (addJsCrazy 10 "99" + 20)

// 8. Alternatively, you can make an interface that maps to the
// bits of the module that you want to expose in F#.
type IUpperCaseModule =
    abstract upperCase : string -> string
    abstract localeUpperCase : string * string -> string

let ucModule = importAll<IUpperCaseModule> "upper-case"
console.log (ucModule.upperCase "module uppercase")
console.log (ucModule.localeUpperCase("module uppercase FR", "fr"))

// 9. Try dynamic typing - import as object and then use ? operator to dynamically call the function
let upperCaseDyn : obj = importAll "upper-case"
console.log(upperCaseDyn?upperCase "dynamic uppercase")