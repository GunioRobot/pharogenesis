collect: aBlock
	| copy |
	copy _ self species new: self size.
	1 to: self size do:[:i| copy at: i put: (aBlock value: (self at: i))].
	^copy