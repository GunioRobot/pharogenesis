noCheckAdd: anObject
	array at: (self findElementOrNil: (keyBlock value: anObject)) put: anObject.
	tally _ tally + 1