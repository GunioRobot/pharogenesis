primTestFailureReturn

	self primitive: 'primTestFailureReturn'
		parameters: #()
		receiver: #Oop.

	1 == 1 ifTrue: [^interpreterProxy primitiveFail].
	^ 17 asOop: SmallInteger