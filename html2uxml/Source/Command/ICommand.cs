namespace html2uxmlSharpDev.source.Command;

public interface ICommand
{
    void Execute();
}

public interface ICommand<in TIn, out TOut>
{
    TOut Execute(TIn args);
}

public interface ICommand<out TOut>
{
    TOut Execute();
}