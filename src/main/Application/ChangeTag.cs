using CQRSlite.Commands;
using org.neurul.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace works.ei8.Data.Tag.Application
{
    public class ChangeTag : ICommand
    {
        public ChangeTag(Guid id, string newTag, Guid authorId, int expectedVersion)
        {
            AssertionConcern.AssertArgumentValid(
                g => g != Guid.Empty,
                id,
                Messages.Exception.InvalidId,
                nameof(id)
                );
            AssertionConcern.AssertArgumentNotNull(newTag, nameof(newTag));
            AssertionConcern.AssertArgumentValid(
                g => g != Guid.Empty,
                authorId,
                Messages.Exception.InvalidId,
                nameof(authorId)
                );
            AssertionConcern.AssertArgumentValid(
                i => i >= 0,
                expectedVersion,
                Messages.Exception.InvalidExpectedVersion,
                nameof(expectedVersion)
                );

            this.Id = id;
            this.NewTag = newTag;
            this.AuthorId = authorId;
            this.ExpectedVersion = expectedVersion;
        }

        public Guid Id { get; private set; }

        public string NewTag { get; private set; }

        public Guid AuthorId { get; set; }

        public int ExpectedVersion { get; set; }
    }
}
