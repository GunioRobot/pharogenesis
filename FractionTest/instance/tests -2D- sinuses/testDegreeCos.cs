testDegreeCos
	"self run: #testDegreeCos"
	
	self shouldnt: [ (4/3) degreeCos] raise: Error.
	self assert: (1/3) degreeCos printString =  '0.999983076857744'