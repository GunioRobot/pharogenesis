primFooIntegerIdentity: x

	self 
		primitive: 	'primFooIntegerIdentity'
		parameters: #(SmallInteger)
		receiver: 	#Oop.

	^ x asOop: SmallInteger