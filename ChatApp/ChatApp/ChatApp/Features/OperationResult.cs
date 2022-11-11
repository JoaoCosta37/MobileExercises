using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatApp.Features
{
    public class OperationResult
    {
        private readonly Dictionary<string, List<String>> _messages = new Dictionary<string, List<String>>();
        public bool HasTransaction { get; set; }
        public Dictionary<string, List<String>> Errors { get; }
        public object Result { get; set; }
        public bool Successful => !Errors.Any();

        public OperationResult() => Errors = _messages;

        public OperationResult(object result) : this() => Result = result;

        public OperationResult AddError(string key, string message)
        {
            List<String> messages;

            if (_messages.ContainsKey(key))
            {
                messages = _messages[key];
            }
            else
            {
                messages = new List<string>();
                _messages.Add(key, messages);
            }

            messages.Add(message);

            return this;
        }

        public OperationResult AddError(string key, string[] messages)
        {
            foreach (var message in messages)
                AddError(key, message);

            return this;
        }

        public static OperationResult Success(object result) => new OperationResult(result);

        public static OperationResult Failure(string key, string message)
        {
            var result = new OperationResult() { };
            result.AddError(key, message);

            return result;
        }
    }
}
