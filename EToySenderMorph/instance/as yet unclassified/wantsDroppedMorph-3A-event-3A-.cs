wantsDroppedMorph: aMorph event: evt

	| dz |
	dz _ self valueOfProperty: #specialDropZone ifAbsent: [^false].
	(dz bounds containsPoint: (evt cursorPoint)) ifFalse: [^false].
	^true.