stillOut		"Smalltalk stillOut"
	"Write transcript the names of the Environments in the list who are still out on disk."

	Transcript clear.
	Smalltalk associationsDo:
		[:assn |
		(assn value isKindOf: Environment) ifTrue:
			[Transcript cr; nextPutAll: assn key , 
					(assn value isInMemory
							ifTrue: [':  in']
							ifFalse: [':  out'])]].
	Transcript endEntry