rehash
	"Overriden to copy the size also - we may have lost any number of elements"
	| newSelf |
	newSelf := self species new: self size.
	self associationsDo:[:each| newSelf noCheckAdd: each].
	array := newSelf array.
	tally := newSelf size.
