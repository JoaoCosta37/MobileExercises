using ChatApp.Models;
using ChatApp.Service;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.Features
{
    public class NewChatRoom 
    {
        public class Command : IRequest<OperationResult>
        {
            public ChatRoom ChatRoom { get; set; } 

        }

        public class CommandValidator : IPipelineBehavior<Command,OperationResult>
        {
            private readonly IChatRoomService chatRoomService;

            public CommandValidator(IChatRoomService chatRoomService, IEnumerable<IRequestPreProcessor<Command>> preProcessors) 
            {
                this.chatRoomService = chatRoomService;
            }
            public async Task<OperationResult> Handle(Command request, CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
            {
                var exist = await chatRoomService.ExistChatRoom(request.ChatRoom.Id);
                if (exist)
                {
                    return OperationResult.Failure("*", "Chat já exite");
                }
                else
                {
                    return await next();
                }

            }

            
        }

        public class Handler : IRequestHandler<Command, OperationResult>
        {
            private readonly IChatRoomService chatRoomService;

            public Handler(IChatRoomService chatRoomService)
            {
                this.chatRoomService = chatRoomService;
            }

            public async Task<OperationResult> Handle(Command request, CancellationToken cancellationToken)
            {
                await chatRoomService.CreateChatRoomAsync(request.ChatRoom);

                return OperationResult.Success("OK");

            }

            //public Task<OperationResult> IRequestHandler<Command, OperationResult>Handle(Command request, CancellationToken cancellationToken)
            //{
            //    await chatRoomService.CreateChatRoomAsync(request.ChatRoom);

            //    throw new NotImplementedException();
            //}
        }
    }
}
