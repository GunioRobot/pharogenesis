wantsDroppedMorph: aMorph event: evt

	self isTheRealProjectPresent ifFalse: [^false].
	project isMorphic ifFalse: [^false].
	project world viewBox ifNil: [^false].		"uninitialized"
	^true