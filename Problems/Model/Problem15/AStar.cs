namespace AdventOfCode.Problems.Model.Problem15
{
    public class AStar
    {
        private int[][] Labyrinth;

        public AStar(int[][] labyrinth)
        {
            Labyrinth = labyrinth;
        }

        private bool IsEnd(Coords coords)
            => coords.X == Labyrinth[0].Length - 1 && coords.Y == Labyrinth.Length - 1;

        public int Solve()
        {
            var currentNode = (Coords: new Coords(X: 0, Y: 0), Weight: 0);
            var isSolution = false;
            var openNodesByWeight = new SortedList<int, List<Coords>>();
            var openNodesCoords = new Dictionary<Coords, int>();
            var closedNodes = new Dictionary<Coords, bool>();

            while (!isSolution)
            {
                var neighbors = OnlyValid(GetNeighbors(currentNode.Coords));

                foreach (var neighbor in neighbors)
                {
                    // If it's already closed, we won't go back.
                    if (closedNodes.ContainsKey(neighbor))
                    {
                        continue;
                    }

                    var pathWeight = currentNode.Weight + Labyrinth[neighbor.Y][neighbor.X];

                    // Check if we will have to update (if it already exists) or add the new code
                    if (openNodesCoords.ContainsKey(neighbor))
                    {
                        var currentWeight = openNodesCoords[neighbor];

                        if (currentWeight > pathWeight)
                        {
                            openNodesByWeight[currentWeight].Remove(neighbor);
                            AddToSortedList(openNodesByWeight, neighbor, pathWeight);
                        }
                    }
                    else
                    {
                        AddToSortedList(openNodesByWeight, neighbor, pathWeight);
                    }

                    openNodesCoords[neighbor] = pathWeight;
                }

                // Add to closed nodes the processed node.
                closedNodes[currentNode.Coords] = true;

                // Update currentNode
                var currentNodeByWeight = openNodesByWeight.First();
                currentNode = (Coords: currentNodeByWeight.Value.First(), Weight: currentNodeByWeight.Key);

                // Remove current node from open nodes.
                currentNodeByWeight.Value.Remove(currentNode.Coords);
                if (currentNodeByWeight.Value.Count() == 0)
                {
                    openNodesByWeight.Remove(currentNodeByWeight.Key);
                }

                openNodesCoords.Remove(currentNode.Coords);

                // Update isSolution
                isSolution = IsEnd(currentNode.Coords);
            }

            return currentNode.Weight;
        }

        private void AddToSortedList(SortedList<int, List<Coords>> openNodesByWeight, Coords neighbor, int pathWeight)
        {
            if (openNodesByWeight.ContainsKey(pathWeight))
            {
                openNodesByWeight[pathWeight].Add(neighbor);
            }
            else
            {
                openNodesByWeight[pathWeight] = new List<Coords> { neighbor };
            }
        }

        private IEnumerable<Coords> GetNeighbors(Coords currentNode)
        {
            return new List<Coords>
                {
                    currentNode with { Y = currentNode.Y - 1 },
                    currentNode with { X = currentNode.X - 1 },
                    currentNode with { X = currentNode.X + 1 },
                    currentNode with { Y = currentNode.Y + 1 },
                };
        }

        private IEnumerable<Coords> OnlyValid(IEnumerable<Coords> coords)
            => coords.Where(c => c.X >= 0 && c.X < Labyrinth[0].Length && c.Y >= 0 && c.Y < Labyrinth.Length);

    }
}
