primTestNonSpecificationCalls

	self primitive: 'primTestNonSpecificationCalls'
		parameters: #()
		receiver: #Oop.

	^(self collateralProcedure) asOop: #SmallInteger