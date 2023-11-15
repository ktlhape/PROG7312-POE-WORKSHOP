using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_POE
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Tree<T>
    {
        public Node<T> Root { get; set; }
        public List<Node<T>> Nodes { get;} = new List<Node<T>>();
        private Stack<Node<T>> _stk = new Stack<Node<T>>();
        public Tree(Node<T> _root)
        {
            this.Root = _root;
            Nodes.Add(Root);
            _stk.Push(Root);
        }
        public Tree<T> CreateBranch(T data)
        {
            if (_stk.Count == 0) //100
            {
                Node<T> newNode = new Node<T>(data, null);
                Nodes.Add(newNode);
                _stk.Push(newNode);
            }
            else
            {                       //100
                Node<T> parentNode = _stk.Peek().AddChild(data);
                _stk.Push(parentNode);
            }
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Tree<T> CloseBranch()
        {
            _stk.Pop();
            return this;
        }
        public Tree<T> Add(T data)
        {
            _stk.Peek().AddChild(data);
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Node<T> Find(Node<T> node, Func<Node<T>,bool> predicate)
        {
            if(predicate(node)) return node;
            foreach (Node<T> n in node.Children)
            {
                Node<T> found = Find(n, predicate);
                if (found != null) return found;
            }
            return null;
        }


    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Parent { get; set; }
        public List<Node<T>> Children { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parent"></param>
        public Node(T data, Node<T> parent)
        {
            this.Data = data;
            this.Parent = parent;
            this.Children = new List<Node<T>>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Node<T> AddChild(T data)
        {
            Node<T> newNode = new(data,this);
            this.Children.Add(newNode);
            return newNode;
        }

    }
}
