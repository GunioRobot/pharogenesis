contains: aPoint 
	| triangle |
	(self whereIs: aPoint)
		= #outside
		ifTrue: [^ nil]
		ifFalse: [self subTriangles isEmptyOrNil ifTrue: [^ self]
		ifFalse: [self subTriangles do: [:subTriangle | 
			triangle _ subTriangle contains: aPoint.
			triangle ifNotNil: [^triangle]]]]