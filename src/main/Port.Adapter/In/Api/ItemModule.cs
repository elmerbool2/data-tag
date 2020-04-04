using CQRSlite.Commands;
using Nancy;
using System;
using works.ei8.Data.Tag.Application;

namespace works.ei8.Data.Tag.Port.Adapter.In.Api
{
    public class ItemModule : NancyModule
    {
        public ItemModule(ICommandSender commandSender) : base("/{avatarId}/data/tags")
        {
            this.Put("/{itemId}", async (parameters) =>
            {
                return await Helper.ProcessCommandResponse(
                        commandSender,
                        this.Request,
                        true,
                        (bodyAsObject, bodyAsDictionary, expectedVersion) =>
                        {
                            return new ChangeTag(
                                parameters.avatarId,
                                Guid.Parse(parameters.itemId.ToString()),
                                bodyAsObject.Tag.ToString(),
                                Guid.Parse(bodyAsObject.AuthorId.ToString()),
                                expectedVersion
                                );                            
                        },
                        "Tag",
                        "AuthorId"
                    );
            }
            );
        }
    }
}
