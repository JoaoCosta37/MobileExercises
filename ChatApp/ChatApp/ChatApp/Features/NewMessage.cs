using ChatApp.Models;
using ChatApp.Service;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Features
{
    public class NewMessage
    {
        public class Command : IRequest<OperationResult>
        {
            public Message Message { get; set; }
        }

        //public class CommandValidator : IPipelineBehavior<Command, OperationResult>
        //{
        //    private readonly IMessageService messageService;

        //    public CommandValidator(IMessageService messageService, IEnumerable<IRequestPreProcessor<Command>> preProcessors)
        //    {
        //        this.messageService = messageService;
        //    }
        //    public async Task
        //}
    }
}
