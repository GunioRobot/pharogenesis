testCreation
	"self run: #testCreation"
	"self debug: #testCreation"

	| sk |
	sk := SkipList new.
	sk at: 11 put: '111111'.
	sk at: 3 put: '3333'.
	sk at: 7 put: '77777'.
	self assert: (sk at: 7) = '77777'.
	self assert: (sk includes: 7). 

	