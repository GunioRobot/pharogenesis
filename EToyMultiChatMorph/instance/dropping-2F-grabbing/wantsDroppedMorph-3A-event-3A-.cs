wantsDroppedMorph: aMorph event: evt

	(aMorph isKindOf: EToySenderMorph) ifFalse: [^false].
	(bounds containsPoint: evt cursorPoint) ifFalse: [^false].
	^true.