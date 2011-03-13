noCheckAdd: anObject
	array at: (self findElementOrNil: anObject) put: anObject.
	tally _ tally + 1