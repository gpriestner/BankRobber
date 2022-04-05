using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankRobber
{
    public class Node
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }
        public Node Clone() => new Node { Id = Id, X = X, Y = Y, Value = Value };
        public override string ToString() => $"{Id} ";
    }

    public class Nodes
    {
        public List<Node> nodes { get; set; }
        public Nodes()
        {
            nodes = new List<Node> {
                new Node { Id = 0, X = 2, Y = 1, Value = 45 },
                new Node { Id = 1, X = 7, Y = 2, Value = 23 },
                new Node { Id = 2, X = 6, Y = 3, Value = 17 },
                new Node { Id = 3, X = 3, Y = 5, Value = 2 },
                new Node { Id = 4, X = 8, Y = 6, Value = 88 },
                new Node { Id = 5, X = 5, Y = 7, Value = 33 },
                new Node { Id = 6, X = 1, Y = 8, Value = 97 },
            };
        }
        public Nodes(Node n)
        {
            nodes = new List<Node>();
            nodes.Add(n.Clone());
        }
        public Nodes(Nodes nodes)
        {
            this.nodes = new List<Node>();
            foreach(var n in nodes.nodes) this.nodes.Add(n.Clone());
        }
        public Nodes(List<Node> nodes)
        {
            this.nodes = new List<Node>();
            foreach (var n in nodes) this.nodes.Add(n.Clone());
        }
        public Nodes Clone()
        {
            return new Nodes(this.nodes); ;
        }
        public Node this[int index] => nodes[index];
        public IEnumerable<Node> Items 
        {
            get
            {
                foreach (var n in this.nodes) yield return n;
            }
        }
        public int Count => nodes.Count;
        public void RemoveNodes(Nodes n)
        {
            for (int i = this.nodes.Count - 1; i >= 0; i--)
                if (n.ContainsNode(this.nodes[i]))
                    this.nodes.RemoveAt(i);
        }

        private bool ContainsNode(Node n)
        {
            foreach (var node in nodes)
                if (node.Id == n.Id) return true;

            return false;
        }

        public void AddNode(Node node)
        {
            nodes.Add(node);
        }
    }
}
