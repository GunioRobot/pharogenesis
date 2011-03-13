confirmMethod: aText
	| sel |
	sel _ Parser new parseSelector: aText.
	^ (self theClass isMeta 
			and: [(self selectorAlreadyDefined: sel) not] 
			and: [Metaclass isScarySelector: sel])
				ifTrue: [self confirmScarySelector: sel]
				ifFalse: [^ true]