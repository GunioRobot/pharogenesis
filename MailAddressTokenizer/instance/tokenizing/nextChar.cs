nextChar
	self atEndOfChars ifTrue: [ ^nil ].
	pos _ pos + 1.
	^text at: (pos-1)