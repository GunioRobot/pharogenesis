testReadsField
	"self debug: #testReadsField"
	
	| method |
	method := self class compiledMethodAt: #readX.
	self assert: (method readsField: 2).
	
	method := self class compiledMethodAt: #readXandY.
	self assert: (method readsField: 3).
	
	
	"read is not write"
	method := self class compiledMethodAt: #writeX.
	self deny: (method readsField: 2).
	
	method := self class compiledMethodAt: #writeXandY.
	self deny: (method readsField: 2).
	
	method := self class compiledMethodAt: #writeXandY.
	self deny: (method readsField: 3).