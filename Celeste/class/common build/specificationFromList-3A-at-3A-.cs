specificationFromList: list at: index 
	| value |
	value _ list at: index.
	value = #nil
		ifTrue: [value _ nil].
	^ value