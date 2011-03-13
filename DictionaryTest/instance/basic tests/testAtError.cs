testAtError
	"self run: #testAtError"
	
	| dict |
	dict := Dictionary new.
	dict at: #a put: 666.
	self shouldnt: [ dict at: #a ] raise: Error.
	self should: [ dict at: #b ] raise: Error.
	
	