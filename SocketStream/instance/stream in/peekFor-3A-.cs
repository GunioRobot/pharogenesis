peekFor: aCharacter
	self atEnd ifTrue: [^false].
	self inStream atEnd ifTrue: 
		[self receiveData.
		self atEnd ifTrue: [^false]].
	^self inStream peekFor: aCharacter