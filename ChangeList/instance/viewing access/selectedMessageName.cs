selectedMessageName
	| c |
	^ (c _ self currentChange) ifNotNil: [c methodSelector]