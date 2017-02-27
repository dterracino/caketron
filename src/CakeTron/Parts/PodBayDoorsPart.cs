using System;
using System.Collections.Generic;
using Dotbot;

namespace CakeTron.Parts
{
    public sealed class PodBayDoorsPart : MentionablePart
    {
        private readonly HashSet<string> _phrases;

        public PodBayDoorsPart()
        {
            _phrases = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "open the pod bay doors",
                "open the pod bay door",
                "open the door",
                "open the doors"
            };
        }

        protected override bool HandleMention(ReplyContext context, string message)
        {
            foreach (var phrase in _phrases)
            {
                if (Contains(message, phrase, StringComparison.OrdinalIgnoreCase))
                {
                    context.Broadcast($"I'm sorry, {context.Message.User.DisplayName}. I'm afraid I can't do that.");
                    return true;
                }
            }
            return false;
        }

        private static bool Contains(string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }
    }
}