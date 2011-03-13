testWritesField
	"self debug: #testWritesField"

	| method |
	method := self class compiledMethodAt: #writeX.
	self assert: (method writesField: 2).
	
	method := self class compiledMethodAt: #writeXandY.
	self assert: (method writesField: 2).
	
	method := self class compiledMethodAt: #writeXandY.
	self assert: (method writesField: 3).
	
	"write is not read"
	
	method := self class compiledMethodAt: #readX.
	self deny: (method writesField: 2).
	
	method := self class compiledMethodAt: #readXandY.
	self deny: (method writesField: 2).
	
	method := self class compiledMethodAt: #readXandY.
	self deny: (method writesField: 3).