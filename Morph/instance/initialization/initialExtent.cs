initialExtent
	| ext |
	(ext _ self valueOfProperty: #initialExtent)
		ifNotNil:
			[^ ext].
	^ super initialExtent