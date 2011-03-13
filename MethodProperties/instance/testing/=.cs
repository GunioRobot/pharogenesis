= other
	self class == other class ifFalse: [^false].
	self pragmas = other pragmas ifFalse:[^false].
	self selector = other  selector ifFalse:[^false].
	self properties = other  properties ifFalse:[^false].
	^true