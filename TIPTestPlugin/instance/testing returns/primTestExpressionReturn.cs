primTestExpressionReturn

	self primitive: 'primTestExpressionReturn'
		parameters: #()
		receiver: #Oop.

	1 == 1 ifTrue: [^17 asOop: SmallInteger].
	^ 17 asOop: SmallInteger