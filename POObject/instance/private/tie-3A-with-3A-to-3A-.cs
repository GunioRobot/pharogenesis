tie: left with: right to: facets
	| offset |
	left first position = right first position
		ifTrue: [
			facets add:
				(B3DSimpleMeshFace
					with: left first
					with: right second
					with: left second).
				offset _ 1]
		ifFalse: [
			facets add:
				(B3DSimpleMeshFace
					with: right last
					with: (left at: Subdivisions)
					with: (right at: Subdivisions)).
				offset _ 0].

	1 + offset to: Subdivisions - 1 + offset do:
		[:idx|
			facets add:
					(B3DSimpleMeshFace
						with: (left at: idx)
						with: (right at: idx)
						with: (left at: idx + 1));
				add:
					(B3DSimpleMeshFace
						with: (right at: idx)
						with: (right at: idx + 1)
						with: (left at: idx + 1))]



