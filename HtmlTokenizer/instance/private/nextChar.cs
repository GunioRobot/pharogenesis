nextChar
	| c |
	self atEnd ifTrue: [ ^nil ].
	c _ text at: pos.
	pos _ pos + 1.
	^c