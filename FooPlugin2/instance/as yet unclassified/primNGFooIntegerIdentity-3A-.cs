primNGFooIntegerIdentity: x

	self 
		primitive: 	'primNGFooIntegerIdentity'
		parameters: #(SmallInteger)
		receiver: 	#Oop.
	self suppressFailureGuards: true.

	^ x asOop: SmallInteger