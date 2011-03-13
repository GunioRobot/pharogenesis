testDegreeCos
	"self run: #testDegreeCos"
	
	self shouldnt: [ 45 degreeCos] raise: Error.
	self assert: 45  degreeCos printString =  (2 sqrt / 2) asFloat printString 