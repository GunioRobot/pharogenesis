readFloatVector: n do: aBlock
	| vec value |
	self backup.
	vec := Array new: n.
	1 to: n do:[:i |
		value := self readFloat.
		value isNil ifTrue:[self restore. ^nil].
		vec at: i put: value.
		i < n ifTrue:[self skipSeparators].
	].
	self discard.
	^aBlock value: vec