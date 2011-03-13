testIncludesAssociation
	"self run:#testIncludesAssociation"
	
	| dict |
	dict := Dictionary new.
	dict at: #a put: 1.
	dict at: #b put: 2.
	self assert: (dict includesAssociation: (#a -> 1)).
	self assert: (dict includesAssociation: (#b -> 2)).
	
	