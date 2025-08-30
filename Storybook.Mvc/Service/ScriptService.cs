using System.Collections.Generic;
using System.Linq;
using Storybook.Mvc.Models;

namespace Storybook.Mvc.Services
{
    public class ScriptService : IScriptService
    {
        private readonly StoryLinkedList _list;

        public ScriptService()
        {
            _list = new StoryLinkedList();

            // UNORDERED on purpose — merge sort will order by Number
            _list.AddLast(7, "The Wolf hurries to Grandmother’s cottage, swallows her up, and disguises himself in her nightcap and gown.");
            _list.AddLast(2, "Her mother asks her to bring cake and a small pot of butter to her ailing grandmother who lives deeper in the wood.");
            _list.AddLast(10, "Red Riding Hood notices the great ears, eyes, hands, and teeth—too late— the Wolf leaps from bed and devours her.");
            _list.AddLast(5, "They speak; the Wolf suggests different paths and distracts her with flowers and birdsong so she lingers among the trees.");
            _list.AddLast(12, "They fill the Wolf’s belly with stones; he wakes, stumbles, and collapses. Grandmother and Red Riding Hood share the cake and vow never to stray again.");
            _list.AddLast(1, "A cheerful girl called Little Red Riding Hood sets out wearing her red hooded cloak.");
            _list.AddLast(4, "In the forest she meets a Wolf who asks where she is going. Innocently, she tells him about Grandmother’s cottage.");
            _list.AddLast(3, "Her mother warns her: stay on the path, do not talk to strangers, and do not tarry.");
            _list.AddLast(8, "Soon after, Red Riding Hood arrives and finds the door ajar. She approaches the bed and remarks how strange Grandmother looks.");
            _list.AddLast(6, "Meanwhile, she wanders off the path to gather flowers while the Wolf runs straight to the cottage.");
            _list.AddLast(9, "A passing Woodcutter hears the commotion, rushes in, and, with a careful cut, frees Grandmother from the Wolf’s belly.");
            _list.AddLast(11, "The Woodcutter spares the Wolf no more harm but decides to teach a lesson.");

            _list.Sort();
        }

        public int Count => _list.Count;

        public IReadOnlyList<StoryNode> GetSortedScript()
            => _list.Enumerate().ToList();

        public StoryNode? GetLine(int index)
            => (index >= 0 && index < _list.Count) ? _list.GetAt(index) : null;
    }
}
