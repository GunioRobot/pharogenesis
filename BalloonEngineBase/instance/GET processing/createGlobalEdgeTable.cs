createGlobalEdgeTable
	"Create the global edge table"
	| object end |
	self inline: false.
	object _ 0.
	end _ objUsed.
	[object < end] whileTrue:[
		"Note: addEdgeToGET: may fail on insufficient space but that's not a problem here"
		(self isEdge: object) ifTrue:[
			"Check if the edge starts below fillMaxY."
			(self edgeYValueOf: object) >= self fillMaxYGet ifFalse:[
				self checkedAddEdgeToGET: object.
			].
		].
		object _ object + (self objectLengthOf: object).
	].