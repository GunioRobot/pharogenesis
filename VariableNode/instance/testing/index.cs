index
	"This code attempts to reconstruct the index from its encoding in code."
	self code < 0 ifTrue:[^ nil].
	self code > 256 ifTrue:[^ self code \\ 256].
	^self code - self type