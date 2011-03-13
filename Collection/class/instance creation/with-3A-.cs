with: anObject 
	"Answer an instance of me containing anObject."

	| newCollection |
	newCollection _ self new.
	newCollection add: anObject.
	^newCollection