using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankRobber
{
    public class Journey
    {
        public Nodes Nodes { get; private set; }
        public double Distance { get; set; }
        public int Total { get; set; }
        public Journey(Nodes nodes)
        {
            this.Nodes = nodes.Clone();
            var distance = 0d;
            foreach (var node in this.Nodes.Items) Total += node.Value;

            for (int i = 0; i < Nodes.Count; i++)
            {
                if (i == 0)
                {
                    var node = Nodes[i];
                    var x = node.X;
                    var y = node.Y;
                    distance += Math.Sqrt(x * x + y * y);
                }
                else
                {
                    var nodePrev = Nodes[i - 1];
                    var nodeThis = Nodes[i];
                    distance += Math.Sqrt(Math.Pow(nodePrev.X - nodeThis.X, 2) + Math.Pow(nodePrev.Y - nodeThis.Y, 2));
                }
            }

            var nodeLast = Nodes[Nodes.Count - 1];
            var nodeEnd = new Node { X = 9, Y = 9 };
            distance += Math.Sqrt(Math.Pow(nodeLast.X - nodeEnd.X, 2) + Math.Pow(nodeLast.Y - nodeEnd.Y, 2));

            Distance = distance;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var node in Nodes.Items) sb.Append(node.ToString());
            sb.Append($"Total: {Total} ");
            sb.Append($"Distance: {Distance:0.00}");
            return sb.ToString();
        }
    }
}
