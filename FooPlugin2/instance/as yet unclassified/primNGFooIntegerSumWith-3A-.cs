primNGFooIntegerSumWith: x

	|rcvr myInteger|
	rcvr _ self 
		primitive: 	'primNGFooIntegerSumWith'
		parameters: #(SmallInteger)
		receiver: 	#Foo2.
	self suppressFailureGuards: true.

	myInteger _ (rcvr asIf: Foo2 var: 'myInteger') asValue: SmallInteger.
	^ (x + myInteger) asOop: SmallInteger