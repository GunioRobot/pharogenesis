circulation
"The circulation of a simple polygon can be #left (counterclockwise) or #right (clockwise)"
	| mostLeft |
	self isSimple
		ifTrue: 
			[mostLeft _ self asSortedCollection first.
			^ (self before: mostLeft)
				to: mostLeft sideOf: (self after: mostLeft)].
	self error: 'Polygon is not simple!'