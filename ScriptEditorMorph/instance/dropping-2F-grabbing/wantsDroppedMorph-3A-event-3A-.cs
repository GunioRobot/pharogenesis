wantsDroppedMorph: aMorph event: evt

	aMorph isTileLike ifFalse: [^false].
	aMorph resultType == #command ifFalse: [^false].
	self isTextuallyCoded ifTrue: [^false].
	^true

