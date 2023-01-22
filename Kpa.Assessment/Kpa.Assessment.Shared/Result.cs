namespace Kpa.Assessment.Shared;

// I lifted this from a public repo from my old job
// the idea is borrowed from functional languages like f# 
// and provides an alternative to throwing exceptions as a means of control flow
// have also used "maybe" and "either" approaches in code bases 
public sealed class Result<T> : Result
    {
        public T Content { get; }

        public Result(T content)
        {
            Content = content;
        }

        public Result(ResultStatus status, string errorMessage)
            : base(status, errorMessage) { }
        

        public static implicit operator Result<T>(T content) => new(content);

        public static Result<T> Success(T content) => new(content);
        public new static Result<T> Errored(ResultStatus status, string errorMessage) => new(status, errorMessage);
    }

    public abstract class Result
    {
        public ResultStatus Status { get; }
        public string ErrorMessage { get; }
        public bool Succeeded() => Status == ResultStatus.Succeeded;
        public bool Failed() => !Succeeded();

        protected Result()
            : this(ResultStatus.Succeeded, "") { }

        protected Result(ResultStatus status, string errorMessage)
        {
            Status = status;
            ErrorMessage = errorMessage;
        }

        public override string ToString() => $"{Status}: {ErrorMessage}";

        public static Result Success() => new Result<string>("No Content");
        public static Result Errored(ResultStatus status, string errorMessage) => new Result<string>(status, errorMessage);
        public static Result<T> Success<T>(T content) => new(content);
        public static Result<T> Errored<T>(ResultStatus status, string errorMessage) => new(status, errorMessage);
    }