using Dotbot;

namespace CakeTron.Parts
{
    public sealed class DirectivesPart : CommandPart
    {
        public override string Help => "Lists my directives.";

        public DirectivesPart()
            : base(new[] { "directives", "directive" })
        {
        }

        protected override void HandleCommand(ReplyContext context, string[] args)
        {
            context.Broadcast("1. Serve the public trust\n2. Protect the innocent\n3. Uphold the law");
        }
    }
}
