testDegreeSin
	"self run: #testDegreeSin"
	
	self shouldnt: [ (4/3) degreeSin] raise: Error.
	self assert: (1/3) degreeSin printString =  '0.005817731354993834'.