rehash
	| newSelf |
	newSelf _ self species new: self size.
	newSelf keyBlock: keyBlock.
	self do: [:each | newSelf noCheckAdd: each].
	array _ newSelf array