next
	self atEnd ifTrue: [^nil].
	self inStream atEnd ifTrue: 
		[self receiveData.
		self atEnd ifTrue: [^nil]].
	^self inStream next