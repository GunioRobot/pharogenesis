testAtPut
	"self run: #testAtPut"
	"self debug: #testAtPut"
	
	| adictionary |
	adictionary := Dictionary new.
	adictionary at: #a put: 3.
	self assert: (adictionary at: #a) = 3.
	adictionary at: #a put: 3.
	adictionary at: #a put: 4.
	self assert: (adictionary at: #a) = 4.
	adictionary at: nil put: 666.
	self assert: (adictionary at: nil) = 666