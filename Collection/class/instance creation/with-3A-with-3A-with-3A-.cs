with: firstObject with: secondObject with: thirdObject 
	"Answer an instance of me containing the three arguments as elements."

	| newCollection |
	newCollection _ self new.
	newCollection add: firstObject.
	newCollection add: secondObject.
	newCollection add: thirdObject.
	^newCollection