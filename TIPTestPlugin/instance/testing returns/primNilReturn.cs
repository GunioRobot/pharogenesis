primNilReturn

	self primitive: 'primNilReturn'
		parameters: #()
		receiver: #Oop.

	interpreterProxy failed ifTrue: [^nil].
	^ nil