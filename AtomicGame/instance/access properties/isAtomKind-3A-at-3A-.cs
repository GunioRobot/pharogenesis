isAtomKind: aKind at: aPosition 
	| morph |
	morph _ self somethingAt: aPosition.
	
	^ morph isKindOf: aKind