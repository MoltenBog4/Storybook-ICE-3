using System.Collections.Generic;
using Storybook.Mvc.Models;

namespace Storybook.Mvc.Services
{
    public interface IScriptService
    {
        int Count { get; }
        IReadOnlyList<StoryNode> GetSortedScript();
        StoryNode? GetLine(int index);
    }
}
