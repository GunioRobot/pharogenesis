findNextExternalUpdateFromAET
	"Check the active edge table for any entries that cannot be handled by the engine itself.
	If there are any, return true. Otherwise, step the the edge to the next y value."
	| edge count type |
	self inline: false.
	[self aetStartGet < self aetUsedGet] whileTrue:[
		edge _ aetBuffer at: self aetStartGet.
		count _ (self edgeNumLinesOf: edge) - 1.
		count = 0 ifTrue:[
			"Edge at end -- remove it"
			self removeFirstAETEntry
		] ifFalse:[
			"Store remaining lines back"
			self edgeNumLinesOf: edge put: count.
			type _ self objectTypeOf: edge.
			(type bitAnd: GEPrimitiveWideMask) = GEPrimitiveEdge 
				ifTrue:[^true]. "This is an external edge"
			self dispatchOn: type in: EdgeStepTable.
			self resortFirstAETEntry.
			self aetStartPut: self aetStartGet+1.
		].
	].
	^false