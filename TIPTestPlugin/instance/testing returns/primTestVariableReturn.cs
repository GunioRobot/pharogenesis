primTestVariableReturn

	| x |
	self primitive: 'primTestVariableReturn'
		parameters: #()
		receiver: #Oop.

	x _ 17 asOop: SmallInteger.
	1 == 1 ifTrue: [^x].
	^ x