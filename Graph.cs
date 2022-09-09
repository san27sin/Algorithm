using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    /// <summary>
    /// Вершина
    /// </summary>
    class Vertex
    {
        public int Number { get; set; }

        public Vertex(int number)
        {
            Number = number;
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }

    /// <summary>
    /// класс ребра
    /// </summary>
    class Edge
    {        
        public Vertex From { get; set; }//из какой точки
        public Vertex To { get; set; }//в какую
        public int Weight { get; set; }//вес

        public Edge(Vertex from, Vertex to, int weight = 1)//по умолчанию 1
        {
            From = from;
            To = to;
            Weight = weight;
        }
    }

    class Graph
    {
        //Список вершин
        List<Vertex> Vertexes = new List<Vertex>();
        //Список ребер
        List<Edge> Edges = new List<Edge>();

        /// <summary>
        /// Добавление вершины
        /// </summary>
        /// <param name="vertex">вершина</param>
        public void AddVertex(Vertex vertex)
        {
            Vertexes.Add(vertex);
        }

        /// <summary>
        /// Добавления ребра
        /// </summary>
        /// <param name="edge"></param>
        public void AddEdge(Vertex from, Vertex to, int weight=1)
        {
            var edge = new Edge(from, to, weight);
            Edges.Add(edge);
        }

        /// <summary>
        /// Получаем все связи определенной вершины
        /// </summary>
        /// <param name="vert"></param>
        /// <returns></returns>
        public List<Edge> GetEdgesOfPoint(Vertex vert)
        {
            var edges = new List<Edge>();
            foreach(var ed in Edges)
            {
                if (ed.From == vert)
                    edges.Add(ed);
            }

            return edges;
        }

        public List<Vertex> GetVertexList(Vertex vertex)
        {
            var result = new List<Vertex>();

            foreach(var edge in Edges)
            {
                if(edge.From == vertex)
                {
                    result.Add(edge.To);
                }
            }

            return result;
        }

        /// <summary>
        /// Поиск в ширину
        /// </summary>
        /// <param name="start">начальная точка</param>
        /// <param name="finish">конечная точка</param>
        /// <returns>кратчайший путь из вершин</returns>
        public Vertex BFS(Vertex start, Vertex finish)
        {
            List<Vertex> visited = new List<Vertex>();
            Queue<Vertex> checkEdges = new Queue<Vertex>();
            checkEdges.Enqueue(start);

            while(checkEdges.Any())
            {
                var tempVer = checkEdges.Dequeue();
                Console.Write($"{tempVer.Number} -> ");
                var list = GetVertexList(tempVer);
                foreach(var search in list)
                {
                    if (visited.Contains(tempVer))
                        continue;

                    if (search == finish)
                    {
                        Console.Write($"{search.Number} -> ");
                        WorkWithConsole();
                        return search;
                    }
                        
                    checkEdges.Enqueue(search);
                }
                visited.Add(tempVer);
            }
            WorkWithConsole();
            return null;
        }

        /// <summary>
        /// Алгоритм дейкстры
        /// </summary>
        /// <param name="start">начальная точка</param>
        /// <param name="finish">конечная</param>
        /// <returns></returns>
        public Vertex DFS(Vertex start, Vertex finish)
        {
            List<Vertex> visited = new List<Vertex>();
            Stack<Vertex> dfs = new Stack<Vertex>();
            dfs.Push(start);

            while(dfs.Any())
            {
                Vertex temp = dfs.Pop();
                var listTemp = GetEdgesOfPoint(temp);
                Console.Write($"{temp.Number} -> ");
                Dictionary<int, Vertex> unsort = new Dictionary<int, Vertex>();


                if (finish == temp)
                {
                    WorkWithConsole();
                    return temp;
                }
                    

                foreach (var search in listTemp)
                {
                    if (visited.Contains(temp))
                        continue;

                    unsort.Add(search.Weight, search.To);
                }

                visited.Add(temp);

                var sort = unsort.OrderByDescending(i => i.Key);

                foreach(var a in sort)
                    dfs.Push(a.Value);              
            }
            WorkWithConsole();
            return null;
        }

        private void WorkWithConsole()
        {
            Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop);
            Console.Write("   ");
            Console.WriteLine();
        }
    }
}
