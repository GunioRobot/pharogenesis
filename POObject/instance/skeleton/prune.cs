prune
	| terminals triangle edge corner fanEnds outer fanCenter further edgePrev postProcess untouched junctions sleeves bottom mid1 mid2 index left right newedge inner |
	postProcess _ Set new.
	terminals _ (self triangulation faces select: [:each | each type = #terminal]) keys.
	terminals do: 
		[:terminal | 
		triangle _ terminal.
		edgePrev _ nil.
		edge _ triangle innerEdges first.
		corner _ triangle oppositeVertexOf: edge.
		fanEnds _ OrderedCollection with: corner.
		[triangle type ~= #junction and: [edge hasAllInsideCircle: fanEnds]]
			whileTrue: 
				[self triangulation removeTriangle: triangle;
				 removeEdge: edge.
				triangle _ edge opposite face.
				edgePrev _ edge.
				edge _ (triangle innerEdges copyWithout: edge opposite) first.
				corner _ triangle oppositeVertexOf: edge.
				fanEnds add: corner].
		triangle type = #sleeve
			ifTrue: 
				[self triangulation removeTriangle: triangle.
				outer _ edge next.
				fanCenter _ edge midpoint.
				"self triangulation removeEdge: edge."
				[outer origin = edge origin]
					whileFalse: 
						[further _ outer next.
						self triangulation
							triangle: fanCenter
							to: outer origin
							to: outer destination.
						outer _ further]].
		triangle type = #junction
			ifTrue: 
				[postProcess add: triangle.
				self triangulation removeTriangle: triangle.
				outer _ edgePrev next.
				fanCenter _ triangle center.
				self triangulation removeEdge: edgePrev.
				[outer origin = edgePrev origin]
					whileFalse: 
						[further _ outer next.
						self triangulation
							triangle: fanCenter
							to: outer origin
							to: outer destination.
						outer _ further]]].
	junctions _ (self triangulation faces select: [:each | each type = #junction]) keys.
	postProcess addAll: junctions.
	postProcess do: 
		[:face | 
		self triangulation removeTriangle: face.
		untouched _ face edges select: [:halfedge | self triangulation halfedges includes: halfedge].
		untouched do: 
			[:halfedge | 
			"self triangulation removeEdge: halfedge."
			triangle _ self triangulation
						triangle: face center
						to: halfedge origin
						to: halfedge destination.
			triangle type: #inner.
			edge _ self triangulation edgeFrom: face center to: halfedge origin.
			edge setTag: #border.
			edge opposite setTag: #border.
			edge _ self triangulation edgeFrom: face center to: halfedge destination.
			edge setTag: #border.
			edge opposite setTag: #border]].
	sleeves _ (self triangulation faces select: [:each | each type = #sleeve]) keys.
	sleeves do: 
		[:face | 
		self triangulation removeTriangle: face.
		bottom _ face borderEdges first.
		index _ face edges indexOf: bottom.
		left _ face edges atWrap: index + 1.
		right _ face edges atWrap: index + 2.
		mid1 _ left midpoint.
		mid2 _ right midpoint.
		self triangulation removeEdge: left;
		 removeEdge: right.
		(bottom origin
			isInsideCircle: bottom destination
			with: mid1
			with: mid2)
			ifTrue: [corner _ bottom origin]
			ifFalse: [corner _ bottom destination].
		self triangulation
			triangle: mid1
			to: mid2
			to: corner;
		
			triangle: bottom origin
			to: bottom destination
			to: (face oppositeEdgeOf: corner) midpoint;
		
			triangle: mid2
			to: mid1
			to: (face oppositeVertexOf: bottom).
		edge _ self triangulation edgeFrom: mid1 to: mid2.
		edge setTagAll: #spine].
	terminals _ (self triangulation faces
				select: [:each | each type = #terminal or: [each type = #inner]]) keys.
	terminals do: 
		[:face | 
		self triangulation removeTriangle: face.
		edge _ face innerEdges first.
		corner _ face oppositeVertexOf: edge.
		(self triangulation
			triangle: corner
			to: edge origin
			to: edge midpoint)
			type: face type.
		(self triangulation
			triangle: corner
			to: edge destination
			to: edge midpoint)
			type: face type.
		newedge _ self triangulation edgeFrom: corner to: edge midpoint.
		newedge setTagAll: #spine].
	inner _ (self triangulation faces select: [:each | each type = #inner]) keys.
	inner do: [:face | face edges do: 
			[:halfedge | 
			halfedge clearTag: #border.
			halfedge opposite clearTag: #border]]