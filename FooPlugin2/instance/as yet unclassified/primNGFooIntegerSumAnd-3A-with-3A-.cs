primNGFooIntegerSumAnd: x with: y

	self 
		primitive: 	'primNGFooIntegerSumAnd'
		parameters: #(SmallInteger SmallInteger)
		receiver: 	#Oop.
	self suppressFailureGuards: true.

	^ (x + y) asOop: SmallInteger