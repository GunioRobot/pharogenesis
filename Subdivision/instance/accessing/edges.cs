edges
	"Return the triangulation edges"
	| edges |
	edges := IdentitySet new: 500.
	startingEdge first collectQuadEdgesInto:edges.
	"Build line segments"
	edges := edges collect:[:edge | 
				LineSegment from: edge first origin to: edge first destination].
	"Remove the outer triangulation edges"
	^edges select:[:edge|
			area origin <= edge start and:[edge start <= area corner and:[area origin <= edge end and:[edge end <= area corner]]]]