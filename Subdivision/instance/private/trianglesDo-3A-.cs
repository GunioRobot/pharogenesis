trianglesDo: aBlock
	"Return the full triangulation of the receiver"
	startingEdge first triangleEdges: (stamp _ stamp + 1) do: aBlock.
