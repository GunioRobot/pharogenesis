primTestReturnsWithGuards

	| x |
	self primitive: 'primTestReturnsWithGuards'
		parameters: #()
		receiver: #Oop.
	
	1 == 1 ifTrue: [^nil].
	2 == 2 ifTrue: [^123].
	3 == 3 ifTrue: [^123 asOop: SmallInteger].
	4 == 4 ifTrue: [^self].
	x _ 123 asOop: SmallInteger.
	5 == 5 ifTrue: [^x].
	^ x