primFooIntegerSumWith: x

	|rcvr myInteger|
	rcvr _ self 
		primitive: 	'primFooIntegerSumWith'
		parameters: #(SmallInteger)
		receiver: 	#Foo2.

	myInteger _ (rcvr asIf: Foo2 var: 'myInteger') asValue: SmallInteger.
	^ (x + myInteger) asOop: SmallInteger