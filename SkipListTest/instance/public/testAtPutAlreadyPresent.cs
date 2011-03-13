testAtPutAlreadyPresent
	"self run: #testAtPutAlreadyPresent"
	"self debug: #testAtPutAlreadyPresent"

	| sk |
	sk := SkipList new.
	sk at: 11 put: '111111'.
	sk at: 3 put: '3333'.
	sk at: 7 put: '77777'.
	sk at: 3 put: '666'.
	
	self assert: (sk at: 7) = '77777'.
	self assert: (sk includes: 7). 
	
	self assert: (sk at: 3) = '3333'.
	
	self assert: (sk includes: 3). 
	self assert: (sk size) = 3

	