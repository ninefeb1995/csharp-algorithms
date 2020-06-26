using System.Collections.Generic;

namespace ClassLibrary
{
    public class MiddleLinkedList
    {
        public static ListNode FindMiddleOfLinkedList(ListNode head)
        {
            var i = 1;
            var temp = head;
            var listNodeInList = new List<ListNode>() { temp };
            do
            {
                temp = temp.next;
                if (temp == null)
                {
                    break;
                }
                i++;
                listNodeInList.Add(temp);
            } while (true);

            return listNodeInList[(i / 2)];
        }

        public static ListNode FindMiddleOfLinkedList1(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast?.next != null)
            {
                slow = slow.next;
                fast = fast.next?.next;
            }

            return slow;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
