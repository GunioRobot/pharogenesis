testAnalogousCodeTo
	"self debug: #testAnalogousCodeTo"
	
	method properties at: #zork put: 'hello'.
	self assert: (method = method).
	