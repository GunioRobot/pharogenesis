addOtherHemisphereTo: facets
	| oppositeFacets oppositeVertices vertex |
	oppositeFacets _ OrderedCollection new.

	facets do:
		[:tri|
			oppositeVertices _ Array new: 3.
			1 to: tri size do:
				[:idx|
					vertex _ tri at: idx.
					"vertex position z = 0
						ifFalse: ["
							vertex _ vertex deepCopy.
							vertex position z: (vertex position z negated).
							vertex texCoord ifNotNil: [vertex texCoord u: (1.0 - (vertex texCoord u))].
							vertex normal ifNotNil: [vertex normal z: (vertex normal z negated)].
					self flag: #TODO. "Orientation?"
					oppositeVertices at: idx put: vertex]. 
			oppositeFacets add: (B3DSimpleMeshFace withAll: oppositeVertices)].

	facets addAll: oppositeFacets
					