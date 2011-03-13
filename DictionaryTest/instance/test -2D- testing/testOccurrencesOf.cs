testOccurrencesOf
	"self run:#testOccurrencesOf" 
	
	| dict |
	dict := Dictionary new.
	dict at: #a put: 1.
	dict at: #b put: 2.
	dict at: #c put: 1.
	dict at: #d put: 3.
	dict at: nil put: nil.
	dict at: #z put: nil.
	
	
	self assert: (dict occurrencesOf: 1 ) = 2.
	self assert: (dict occurrencesOf: nil ) = 2.
	
	
	
	