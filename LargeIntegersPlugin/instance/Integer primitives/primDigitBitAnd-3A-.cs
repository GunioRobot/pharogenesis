primDigitBitAnd: secondInteger 
	"Bit logic here is only implemented for positive integers or Zero; if rec 
	or arg is negative, it fails."
	| firstInteger |
	self debugCode: [self msg: 'primDigitBitAnd: secondInteger'].
	firstInteger _ self
				primitive: 'primDigitBitAnd'
				parameters: #(Integer )
				receiver: #Integer.
	^ self
		digitBitLogic: firstInteger
		with: secondInteger
		opIndex: andOpIndex