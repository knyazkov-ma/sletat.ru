using System.Collections.Generic;
using System.Linq;

namespace sletat.ru
{
    public class Node
    {
        public IList<Node> Children { get; set; }
        public string Name { get; set; }
    }

    public static class NodeExtension
    {
        static IEnumerable<Node> descendants(Node root)
        {
            var nodes = new Stack<Node>(new[] { root });
            while (nodes.Any())
            {
                Node node = nodes.Pop();
                yield return node;
                if (node.Children != null && node.Children.Any())
                    foreach (var n in node.Children) nodes.Push(n);
            }
        }

        public static IEnumerable<Node> GetLeafs(this Node root)
        {
            return descendants(root).Where(t => t.Children == null || !t.Children.Any());
        }
    }
}
