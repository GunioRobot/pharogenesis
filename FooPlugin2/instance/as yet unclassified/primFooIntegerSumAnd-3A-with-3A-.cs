primFooIntegerSumAnd: x with: y

	self 
		primitive: 	'primFooIntegerSumAnd'
		parameters: #(SmallInteger SmallInteger)
		receiver: 	#Oop.

	^ (x + y) asOop: SmallInteger