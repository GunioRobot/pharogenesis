messageListIndex: anInteger 
	"Set the selected message selector to be the one indexed by anInteger.  Find all classes it is in."

	selectorIndex _ anInteger.
	selectorIndex = 0 ifTrue: [^ self].

	classList _ Smalltalk allImplementorsOf: self selectedMessageName.
	self markMatchingClasses.
	classListIndex _ 0.
	self changed: #messageListIndex.		"update my selection"
	self changed: #classList.