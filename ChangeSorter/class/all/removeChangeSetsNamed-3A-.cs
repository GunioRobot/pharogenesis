removeChangeSetsNamed: nameList
	| missing rejects aSet |
	missing _ OrderedCollection new.
	rejects _ OrderedCollection new.
	nameList do:
		[:aName |
			aSet _ self changeSetNamed: aName.
			aSet == nil
				ifTrue:
					[missing add: aName]
				ifFalse:
					[(self removeSilently: aSet) 
						ifFalse:	[rejects add: aName]]].
	missing size > 0 ifTrue: [self halt: 'Some were missing'].
	rejects size > 0 ifTrue: [self halt: 'some were rejected']