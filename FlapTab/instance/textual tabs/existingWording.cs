existingWording
	| longForm |
	longForm _ submorphs first contents.
	^ self orientation == #vertical
		ifTrue:
			[longForm asString copyWithout: Character cr]
		ifFalse:
			[(longForm asString collectWithIndex:
				[:ch :i | i even ifFalse: [$»] ifTrue: [ch]]) copyWithout: $»]