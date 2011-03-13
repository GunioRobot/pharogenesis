rehash
	| newSelf |
	newSelf _ self species new: self size.
	self do: [:each | newSelf noCheckAdd: each].
	array _ newSelf array