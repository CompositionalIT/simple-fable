# Fable Minimal App

This is a minimal Fable sample application based off of the [Fable dotnet template](https://github.com/fable-compiler/fable-templates/).

1. Run the app with `node_modules\.bin\webpack-dev-server`.

## Points of interest

1. Observe the file is normal F#, with modules and open statements.
2. We can get a reference to a DOM element using standard DOM browser functions. These are simple F# wrappers around the browser.
3. This includes event handlers.
4. We can even use `window.alert`!
5. We can even use some BCL methods that can magically "transpiled" to equivalent JS methods e.g. DateTime.

6. We can reference modules of other JS files e.g. NPM packages easily using the `import` function
7. We can go even lower and use the `Emit` attribute.
8. Or we can create an interface to match the JS module.
9. If we're feeling dangerous we can do complete dynamic typing using the `?` operator.

> There is a website called TS2Fable which attempts to massage TS definitelytyped interfaces into F#.

> See also [here](https://fable.io/fable-doc/communicate/js-from-fable.html) for more details.