elevateSpine
	| spineVertices triangle edge spineEdges height |
	spineVertices _ self triangulation vertices
				select: [:vertex | (vertex testTag: #spine)
						and: [(self polygon vertices includes: vertex asPoint) not]].
	spineVertices size = 0
		ifTrue: 
			[triangle _ self triangulation faces keys someElement.
			edge _ triangle borderEdges first.
			spineVertices _ Array with: (triangle oppositeVertexOf: edge)].
	spineVertices do: [:vertex | vertex z: ((self triangulation incidentEdgesAt: vertex)
				collect: [:each | each length]) average].
	spineVertices do: 
		[:vertex | 
		spineEdges _ (self triangulation incidentEdgesAt: vertex)
					select: [:halfedge | halfedge testTag: #spine].
		spineEdges size > 0
			ifTrue: 
				[height _ (spineEdges collect: [:halfedge | halfedge destination z]) average.
				vertex z: height]]