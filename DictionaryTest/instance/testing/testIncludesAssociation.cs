testIncludesAssociation
	"self debug: #testIncludesAssociation"

	| d |
	d := Dictionary new 
		at: #five put: 5; 
		at: #givemefive put: 5;
		at: #six put: 6;
		yourself.
		
	self assert: (d includesAssociation: (d associationAt: #five)).
	self assert: (d includesAssociation: (#five -> 5)).
	self assert: (d includesAssociation: (#five -> 6)) not.