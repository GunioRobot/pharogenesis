queueFor: aSymbol
	aSymbol ifNil: [^ self defaultQueue].
	^ self queueDict 
		at: aSymbol 
		ifAbsent: [self queueDict at: aSymbol put: OrderedCollection new].