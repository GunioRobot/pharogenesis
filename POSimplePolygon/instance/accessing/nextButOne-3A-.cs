nextButOne: aVertex 
	| index |
	index _ self vertices indexOf: aVertex.
	^ self vertices atWrap: index + 2