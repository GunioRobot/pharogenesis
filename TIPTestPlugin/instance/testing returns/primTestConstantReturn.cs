primTestConstantReturn

	self primitive: 'primTestConstantReturn'
		parameters: #()
		receiver: #Oop.

	1 == 1 ifTrue: [^ 1]. "Smalltalk Oop for zero"
	^1 "Smalltalk Oop for zero"