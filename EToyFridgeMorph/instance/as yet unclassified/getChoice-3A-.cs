getChoice: aString

	aString = 'group' ifTrue: [^groupMode ifNil: [true]].