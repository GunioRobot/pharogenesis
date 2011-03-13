add: anAssociation
	| index element |
	index _ self findElementOrNil: anAssociation key.
	element _ array at: index.
	element == nil
		ifTrue: [self atNewIndex: index put: anAssociation]
		ifFalse: [element value: anAssociation value].
	^ anAssociation