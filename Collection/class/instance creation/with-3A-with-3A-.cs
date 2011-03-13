with: firstObject with: secondObject 
	"Answer an instance of me containing the two arguments as elements."

	| newCollection |
	newCollection _ self new.
	newCollection add: firstObject.
	newCollection add: secondObject.
	^newCollection