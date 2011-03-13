transformAs: encoder

	(receiver isKindOf: BraceNode)
		ifTrue: 
			[receiver collClass: arguments first.
			^true]
		ifFalse: 
			[^false]