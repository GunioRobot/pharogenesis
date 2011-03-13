toggleChoice: aString

	updateCounter _ nil.		"force rebuild"
	aString = 'group' ifTrue: [^groupMode _ (groupMode ifNil: [true]) not].
