using System.Collections.Generic;

namespace Storybook.Mvc.Models
{
    public class StoryLinkedList
    {
        public StoryNode? Head { get; private set; }

        public void AddLast(int number, string text)
        {
            var n = new StoryNode(number, text);
            if (Head == null) { Head = n; return; }
            var cur = Head;
            while (cur.Next != null) cur = cur.Next;
            cur.Next = n;
        }

        public int Count
        {
            get { int c = 0; var cur = Head; while (cur != null) { c++; cur = cur.Next; } return c; }
        }

        public StoryNode? GetAt(int index)
        {
            int i = 0; var cur = Head;
            while (cur != null)
            {
                if (i == index) return cur;
                i++; cur = cur.Next;
            }
            return null;
        }

        public IEnumerable<StoryNode> Enumerate()
        {
            var cur = Head;
            while (cur != null) { yield return cur; cur = cur.Next; }
        }

        public void Sort() => Head = MergeSort(Head);

        private static StoryNode? MergeSort(StoryNode? head)
        {
            if (head == null || head.Next == null) return head;
            var mid = GetMiddle(head);
            var rightHead = mid.Next;
            mid.Next = null;
            var left = MergeSort(head);
            var right = MergeSort(rightHead);
            return Merge(left, right);
        }

        private static StoryNode GetMiddle(StoryNode head)
        {
            var slow = head; var fast = head;
            while (fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next!; fast = fast.Next.Next!;
            }
            return slow;
        }

        private static StoryNode? Merge(StoryNode? a, StoryNode? b)
        {
            var dummy = new StoryNode(0, "");
            var tail = dummy;
            while (a != null && b != null)
            {
                if (a.Number <= b.Number) { tail.Next = a; a = a.Next; }
                else { tail.Next = b; b = b.Next; }
                tail = tail.Next!;
            }
            tail.Next = a ?? b;
            return dummy.Next;
        }
    }
}
