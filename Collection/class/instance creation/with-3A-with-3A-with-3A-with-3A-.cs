with: firstObject with: secondObject with: thirdObject with: fourthObject 
	"Answer an instance of me, containing the four arguments as the 
	elements."

	| newCollection |
	newCollection _ self new.
	newCollection add: firstObject.
	newCollection add: secondObject.
	newCollection add: thirdObject.
	newCollection add: fourthObject.
	^newCollection