primTestSelfReturn

	self primitive: 'primTestSelfReturn'
		parameters: #()
		receiver: #Oop.

	1 == 1 ifTrue: [^self].
	^ self