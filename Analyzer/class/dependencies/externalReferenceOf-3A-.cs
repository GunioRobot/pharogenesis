externalReferenceOf: aCollectionOfClass 
	| r |
	r := Set new.
	aCollectionOfClass
		do: [:cls | r
				addAll: (self dependenciesForClass: cls)].
	aCollectionOfClass 
		do: [:clss | r
				remove: clss name
				ifAbsent: []].
	^ r