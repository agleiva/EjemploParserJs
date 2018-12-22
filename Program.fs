// Learn more about F# at http://fsharp.org

open System
open System.IO
open Argu
open Jint

type CommandLineArguments = | [<MainCommand>] FilePath of path:string
with
    interface IArgParserTemplate with
        member s.Usage =
            match s with
            | FilePath _ -> "ruta al archivo .js que se desea ejecutar"

[<EntryPoint>]
let main argv =
    let parser = ArgumentParser.Create<CommandLineArguments>(programName = "JsParser.exe")

    let args = parser.ParseCommandLine argv
    
    if not(args.Contains(FilePath)) then
        Console.Write(parser.PrintUsage())
        -1
    else
        let path = args.GetResult(FilePath)
        printf "Ejecutando Archivo: %s" path
        
        let action f = Action<obj>(f)

        let engine = 
            Engine().SetValue("SomethingWrongException", action(fun x -> failwith("Something Wrong")))

        engine.SetValue("A", 5)

        let code = File.ReadAllText(path)

        engine.Execute code

        0
    
    

