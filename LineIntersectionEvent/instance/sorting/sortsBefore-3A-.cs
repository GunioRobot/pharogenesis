sortsBefore: anEvent
	(self position x = anEvent position x and:[self position y = anEvent position y])
		ifFalse:[^self position sortsBefore: anEvent position].
	^self priority > anEvent priority