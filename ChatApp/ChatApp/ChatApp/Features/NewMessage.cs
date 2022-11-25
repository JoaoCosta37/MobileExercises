using ChatApp.Models;
using ChatApp.Service;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ChatApp.Features
{
    public class NewMessage
    {
        public class Command : IRequest<OperationResult>
        {
            public String Message { get; set; }
            public string ChatId { get; set; }
        }

        public class Handler : IRequestHandler<Command, OperationResult>
        {
            private readonly IMessageService messageService;
            private readonly IAuth auth;

            public Handler(IMessageService messageService, IAuth auth)
            {
                this.messageService = messageService;
                this.auth = auth;
            }

            public async Task<OperationResult> Handle(Command request, CancellationToken cancellationToken)
            {

                Message message = new Message() { Author = auth.AuthUser, Date = DateTime.Now, Text = request.Message };

                await messageService.CreateMessageAsync(message, request.ChatId);

                return OperationResult.Success("OK");

            }
        }
    }
}
