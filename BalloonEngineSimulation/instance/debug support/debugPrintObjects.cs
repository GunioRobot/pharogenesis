debugPrintObjects
	| object end |
	self inline: false.
	object _ 0.
	end _ objUsed.
	[object < end] whileTrue:[
		Transcript cr; 
			nextPut:$#; print: object; space;
			print: (self objectHeaderOf: object); space.
		(self isEdge: object) 
			ifTrue:[Transcript nextPutAll:'(edge) '].
		(self isFill:object)
			ifTrue:[Transcript nextPutAll:'(fill) '].
		Transcript print: (self objectLengthOf: object); space.
		Transcript endEntry.
		object _ object + (self objectLengthOf: object).
	].