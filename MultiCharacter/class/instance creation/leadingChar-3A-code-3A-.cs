leadingChar: leadChar code: code

	code >= 16r400000 ifTrue: [
		self error: 'code is out of range'.
	].
	leadChar >= 256 ifTrue: [
		self error: 'lead is out of range'.
	].

	^self value: (leadChar bitShift: 22) + code.
