rehash
	"Smalltalk rehash."
	| newSelf |
	newSelf _ self species new: self size.
	self associationsDo: [:each | newSelf noCheckAdd: each].
	array _ newSelf array