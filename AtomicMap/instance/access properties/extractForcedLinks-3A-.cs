extractForcedLinks: aSymbolList 
	| result requiredClass |
	result _ Bag new.
	aSymbolList
		do: [:item | 
			
			requiredClass _ self getClassOf: item.
			requiredClass
				ifNotNil: [result add: requiredClass]].
	^ result