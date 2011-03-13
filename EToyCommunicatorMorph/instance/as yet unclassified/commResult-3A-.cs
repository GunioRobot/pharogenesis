commResult: anArrayOfAssociations

	| aDictionary |
	aDictionary _ Dictionary new.
	anArrayOfAssociations do: [ :each | aDictionary add: each].
	resultQueue nextPut: aDictionary