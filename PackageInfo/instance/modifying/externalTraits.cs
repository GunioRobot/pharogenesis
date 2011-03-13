externalTraits
	| behaviors |
	
	^ Array streamContents: [:s |
		behaviors := self classesAndMetaClasses.
		Smalltalk allTraits do: [:trait |
			(behaviors includes: trait) ifFalse: [s nextPut: trait].
			(behaviors includes: trait classSide) ifFalse: [s nextPut: trait classSide]]].			