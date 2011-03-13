standardHolder
	| p |
	^ (p _ self presenter) ifNil: [nil] ifNotNil: [p standardHolder]